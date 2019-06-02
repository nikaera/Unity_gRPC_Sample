package main

import (
	"context"
	"errors"
	"fmt"
	"log"
	"net"

	// user_id を発行するために使用するライブラリ
	// 未インストールの場合は go get で取得しておく
	"github.com/google/uuid"
	"google.golang.org/grpc"

	// protoc で出力した *.pb.go を使用する
	pb "nikaera.com/gRPC_sample/world"
)

const (
	port = ":50051"
)

type server struct {
	// 部屋情報を扱う連想配列
	// key には部屋の ID を value にはユーザの ID を格納する
	rooms map[string][]string

	// ユーザ情報を扱う連想配列
	// key にはユーザの ID を value にはユーザ情報を格納する
	users map[string]*pb.User
}

// ルームにユーザが参加しているかどうかを判定するための関数
func (s *server) isExistUser(roomID string, userID string) bool {
	userIDs, _ := s.rooms[roomID]

	for _, v := range userIDs {
		if v == userID {
			return true
		}
	}

	return false
}

// ルームに参加しているユーザリストを取得するための関数
func (s *server) roomUsers(roomID string) []*pb.User {
	var _users []*pb.User
	for _, uid := range s.rooms[roomID] {
		_users = append(_users, s.users[uid])
	}

	return _users
}

// 指定した値が配列の何番目かを取得するための関数
// (指定ユーザが部屋に参加しているユーザリストの中の何番目かを取得するために使用)
func indexOfArray(a []string, v string) int {
	for i, _v := range a {
		if _v == v {
			return i
		}
	}

	return -1
}

// 指定した index の値を配列内から削除するための関数
// (指定ユーザを部屋のユーザリストから削除するために使用)
func unset(s []string, i int) []string {
	if i >= len(s) {
		return s
	}
	return append(s[:i], s[i+1:]...)
}

// ユーザが部屋に参加するときに実行される
func (s *server) Join(ctx context.Context, req *pb.JoinRequest) (*pb.JoinResponse, error) {
	// リクエスト内容から部屋の ID を取得
	// 今回のサンプルでは部屋の ID には "world" のみ使用可能
	roomID := req.GetRoomId()

	// 発行するユーザの ID を生成する
	userUUID, _ := uuid.NewRandom()
	userID := userUUID.String()

	// 指定した部屋が存在していなければ、エラーを発生させる
	_, isExistRoom := s.rooms[roomID]
	if !isExistRoom {
		s := fmt.Sprintf("%s's room not found\n", roomID)
		return nil, errors.New(s)
	}
	// 生成したユーザの ID を部屋のユーザリストに追加する
	s.rooms[roomID] = append(s.rooms[roomID], userID)
	// 生成したユーザの ID に紐づくデータを初期化して users に設定する
	s.users[userID] = &pb.User{
		UserId:    userID,
		Transform: &pb.Transform_{},
		Rotation:  &pb.Rotation_{},
	}

	// 生成したユーザの ID を返却する
	return &pb.JoinResponse{
		UserId: userID,
	}, nil
}

// ユーザが自身のデータ及び部屋に参加しているユーザのデータを同期/取得するときに実行される
func (s *server) Sync(ctx context.Context, req *pb.SyncRequest) (*pb.SyncResponse, error) {
	roomID := req.GetRoomId()
	userID := req.GetUser().GetUserId()

	// 部屋が存在しないか、ユーザが部屋に参加していなかった場合、エラーを発生させる
	_, isExistRoom := s.rooms[roomID]
	if !isExistRoom {
		s := fmt.Sprintf("%s's room not found\n", roomID)
		return nil, errors.New(s)
	}
	if !s.isExistUser(roomID, userID) {
		s := fmt.Sprintf("%s's user not found\n", userID)
		return nil, errors.New(s)
	}

	// 部屋全体に通知するためのユーザ(カメラ)自身の位置情報と回転情報を更新する。
	transform := req.GetUser().GetTransform()
	s.users[userID].Transform.X = transform.GetX()
	s.users[userID].Transform.Y = transform.GetY()
	s.users[userID].Transform.Z = transform.GetZ()

	rotation := req.GetUser().GetRotation()
	s.users[userID].Rotation.EulerX = rotation.GetEulerX()
	s.users[userID].Rotation.EulerY = rotation.GetEulerY()
	s.users[userID].Rotation.EulerZ = rotation.GetEulerZ()

	// 最新の部屋内のユーザリスト情報を取得する
	return &pb.SyncResponse{
		Users: s.roomUsers(roomID),
	}, nil
}

// ユーザが部屋から退出する際に実行される
func (s *server) Leave(ctx context.Context, req *pb.LeaveRequest) (*pb.LeaveResponse, error) {
	roomID := req.GetRoomId()
	userID := req.GetUserId()

	// 部屋が存在しないか、ユーザが部屋に参加していなかった場合、エラーを発生させる
	_, isExistRoom := s.rooms[roomID]
	if !isExistRoom {
		s := fmt.Sprintf("%s's room not found\n", roomID)
		return nil, errors.New(s)
	}
	if !s.isExistUser(roomID, userID) {
		s := fmt.Sprintf("%s's user not found\n", userID)
		return nil, errors.New(s)
	}

	// ユーザの情報を部屋からもユーザリストからも削除する
	index := indexOfArray(s.rooms[roomID], userID)
	s.rooms[roomID] = unset(s.rooms[roomID], index)

	return &pb.LeaveResponse{}, nil
}

func main() {
	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}
	s := grpc.NewServer()
	// gRPC サーバの登録を行う
	// 部屋の ID として "world" だけ初期設定に入れておく
	// "world" という部屋にだけユーザは参加可能になる
	pb.RegisterRoomServer(s, &server{
		rooms: map[string][]string{"world": {}},
		users: map[string]*pb.User{},
	})

	// gRPC サーバの起動を行う
	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}
