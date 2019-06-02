# Unity_gRPC_Sample
A system to synchronize camera position and rotation in Unity and Go on Mac

![demo](https://github.com/nuhs/Unity_gRPC_Sample/blob/master/demo.gif)

# Dependency

## Server
Go 1.12.5

## Client
Unity 2018.3.14f1

# Setup

Install `protoc` command with gRPC plugin using homebrew.
```
brew install protobuf
brew tap grpc/grpc
brew install grpc
go get -u -v github.com/golang/protobuf/protoc-gen-go
```

Move to `Unity_gRPC_Sample/golang_server/nikaera.com/gRPC_sample/world/` with terminal,
and generate grpc related files for go and unity csharp.
```
# For Go gRPC files
protoc -I . --go_out=plugins=grpc:. room.proto user.proto

# For Unity gRPC files
protoc -I ./ --csharp_out=./ --grpc_out=./ --plugin=protoc-gen-grpc=/usr/local/bin/grpc_csharp_plugin room.proto user.proto
```

Copy `Unity_gRPC_Sample/golang_server/nikaera.com` to $GOPATH.
```
cp -r Unity_gRPC_Sample/golang_server/nikaera.com $GOPATH
```

Copy Unity gRPC files to script folder in project.
```
cp Room.cs User.cs RoomGrpc.cs Unity_gRPC_Sample/unity_client/gRPC_sample/Assets/Scripts/gRPC
```

## Unity gRPC Plugin

1. Download the gRPC build from the https://packages.grpc.io/.
2. Click the link that exists in the item of `Build ID`. (ex. [9f70381d-a50b-44b5-87cf-62e43d72037e](https://packages.grpc.io/archive/2019/06/7fce9da88febd7c0d6f6e0fb90ba31e600624623-9f70381d-a50b-44b5-87cf-62e43d72037e/index.xml))
3. Click the `grpc_unity_package.x.xx.x-dev.zip` link of `C#` to download zip file of gRPC library.
4. Extracting the downloaded zip file will create a `Plugin` folder. Move `Plugin` folder to `Unity_gRPC_Sample/unity_client/gRPC_sample/Assets`.

# Usage

1. Move to `Unity_gRPC_Sample/golang_server/nikaera.com/` with terminal, and ｓtart gRPC server as follows.
```
go run server/main.go
```

2. Open the `Unity_gRPC_Sample/unity_client/gRPC_sample` folder several times with Unity.
3. Run each Unity project with the gRPC server running.
4. The position or rotation of the `Main Camera` is moved, the status is reflected in the objects of other Unity projects
5. Rewriting the source code as you like, Have fun!
