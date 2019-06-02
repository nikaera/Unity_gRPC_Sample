using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Grpc.Core;
using World;
using System.Collections.Generic;

public class RoomScript : MonoBehaviour
{
    // 参加したい部屋の ID (現在は "world" のみ有効)
    [SerializeField]
    string roomID;

    // Main Camera をアタッチする
    [SerializeField]
    Transform cameraTransform;

    // 他ユーザを表す Prefab を設定する
    [SerializeField]
    GameObject dummyPrefab;

    // 発行されるユーザの ID を保持する変数
    string userID;

    // gRPC のチャネル及びクライアントを管理するための変数群
    Channel channel;
    World.Room.RoomClient client;

    // 部屋に参加している自分以外のユーザの GameObject (アバター) を管理するための変数
    Dictionary<string, GameObject> userGameObjects = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        // gRPC サーバの TCP リスナー先を指定して、
        // RoomClient クライアントとして接続を行う
        channel = new Channel("localhost:50051", ChannelCredentials.Insecure); 
        client = new World.Room.RoomClient(channel);

        // gRPC サーバの Join を実行し、指定した部屋からユーザの ID を発行してもらう
        JoinResponse response = client.Join(new JoinRequest
        {
            RoomId = this.roomID
        });

        // 発行されたユーザの ID は変数で保持しておく
        this.userID = response.UserId;
    }

    void OnDisable()
    {
        // 参加している部屋から退出する。
        // 退出する際は部屋の ID とユーザ の ID を引数に渡して Leave 関数を実行する
        client.Leave(new LeaveRequest
        {
            UserId = this.userID,
            RoomId = this.roomID,
        });

        // gRPC のチャネルを切る
        channel.ShutdownAsync().Wait();
    }

    // Update is called once per frame
    void Update()
    {
        // 別スレッドでの実行結果をメインスレッドで実行するため
        // メインスレッドのコンテキストを変数として保持しておく
        var context = SynchronizationContext.Current;
        Vector3 position = cameraTransform.position;
        Vector3 rotation = cameraTransform.eulerAngles;

        // 非同期で gRPC サーバの Sync 関数を実行する
        // 参加している部屋の ID とユーザの ID 及び位置/回転情報を引数に渡す
        Task.Run(() =>
        {
            var response = client.Sync(new SyncRequest
            {
                RoomId = this.roomID,
                User = new User
                {
                    UserId = this.userID,
                    Transform = new Transform_
                    {
                        X = position.x,
                        Y = position.y,
                        Z = position.z,
                    },
                    Rotation = new Rotation_
                    {
                        EulerX = rotation.x,
                        EulerY = rotation.y,
                        EulerZ = rotation.z,
                    }
                },
            });

            // 戻り値は部屋に参加している他ユーザの位置/回転情報が含まれたリスト
            var enumrator = response.Users.GetEnumerator();

            // 処理の実行を MainThread に戻す
            // MainThread では他ユーザの様子(位置/回転情報)を
            // Unity シーンに反映させるための処理を行う
            context.Post(__ =>
        {
            SyncRoom(enumrator);
        }, null);
        });
    }

    private void SyncRoom(IEnumerator<User> enumrator)
    {
        // 部屋から存在しなくなったユーザの ID を保持しておくための変数
        var exceptUserIDList = new List<string>(userGameObjects.Keys);

        // gRPC サーバの Sync 関数の実行結果をループで参照する
        while (enumrator.MoveNext())
        {
            var user = enumrator.Current;

            // ユーザリストには自分自身も含まれているため、
            // 自分以外のユーザであった場合にその情報を画面に反映させる
            if (this.userID != user.UserId)
            {
                // 既にユーザの GameObject (アバター)が存在していれば、
                // その GameObject (アバター) を取得する
                // 存在していなければ dummyPrefab で指定した内容で、
                // 該当ユーザの GameObject (アバター) を生成する
                GameObject userGameObject;
                if (userGameObjects.ContainsKey(user.UserId))
                {
                    userGameObject = userGameObjects[user.UserId];
                }
                else
                {
                    userGameObject = Instantiate(dummyPrefab, Vector3.zero, Quaternion.identity, this.transform.root);
                    userGameObjects[user.UserId] = userGameObject;
                }

                // GameObject (アバター) にユーザの位置/回転情報を反映させる。
                userGameObject.transform.position = new Vector3(
                  x: user.Transform.X, y: user.Transform.Y, z: user.Transform.Z
                );
                userGameObject.transform.eulerAngles = new Vector3(
                  x: user.Rotation.EulerX, y: user.Rotation.EulerY, z: user.Rotation.EulerZ
                );

                exceptUserIDList.Remove(user.UserId);
            }
        }

        // Sync レスポンスに含まれていないユーザの ID(退出済みのユーザの ID) が
        // 存在していたら該当ユーザの GameObject(アバター) を削除する
        foreach (var userId in exceptUserIDList)
        {
            Destroy(userGameObjects[userId]);
            userGameObjects.Remove(userId);
        }
    }
}
