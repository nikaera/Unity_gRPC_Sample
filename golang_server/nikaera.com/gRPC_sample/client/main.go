package main

import (
	"context"
	"fmt"
	"log"

	"google.golang.org/grpc"
	pb "nikaera.com/gRPC_sample/world"
)

const (
	address = "localhost:50051"
)

func main() {
	// Set up a connection to the server.
	conn, err := grpc.Dial(address, grpc.WithInsecure())
	if err != nil {
		log.Fatalf("did not connect: %v", err)
	}
	defer conn.Close()
	c := pb.NewRoomClient(conn)

	ctx, cancel := context.WithCancel(context.Background())
	defer cancel()

	roomID := "world"
	r, err := c.Join(ctx, &pb.JoinRequest{
		RoomId: roomID,
	})
	if err != nil {
		log.Fatalf("cant join room")
	}

	userID := r.GetUserId()

	for {
		req, err := c.Sync(ctx, &pb.SyncRequest{
			RoomId: roomID,
			User: &pb.User{
				UserId: userID,
				Transform: &pb.Transform{
					X: 1,
					Y: 2,
					Z: 3,
				},
				Rotation: &pb.Rotation{
					EulerX: 45,
					EulerY: 45,
					EulerZ: 45,
				},
			},
		})

		if err != nil {
			log.Fatalf("Sync Error: %v", err)
		}

		for i, v := range req.Users {
			fmt.Printf("%v, %v\n", i, v)
		}
	}
}
