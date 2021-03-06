// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: room.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace World {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class Room
  {
    static readonly string __ServiceName = "world.Room";

    static readonly grpc::Marshaller<global::World.JoinRequest> __Marshaller_world_JoinRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::World.JoinRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::World.JoinResponse> __Marshaller_world_JoinResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::World.JoinResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::World.SyncRequest> __Marshaller_world_SyncRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::World.SyncRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::World.SyncResponse> __Marshaller_world_SyncResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::World.SyncResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::World.LeaveRequest> __Marshaller_world_LeaveRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::World.LeaveRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::World.LeaveResponse> __Marshaller_world_LeaveResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::World.LeaveResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::World.JoinRequest, global::World.JoinResponse> __Method_Join = new grpc::Method<global::World.JoinRequest, global::World.JoinResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Join",
        __Marshaller_world_JoinRequest,
        __Marshaller_world_JoinResponse);

    static readonly grpc::Method<global::World.SyncRequest, global::World.SyncResponse> __Method_Sync = new grpc::Method<global::World.SyncRequest, global::World.SyncResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Sync",
        __Marshaller_world_SyncRequest,
        __Marshaller_world_SyncResponse);

    static readonly grpc::Method<global::World.LeaveRequest, global::World.LeaveResponse> __Method_Leave = new grpc::Method<global::World.LeaveRequest, global::World.LeaveResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Leave",
        __Marshaller_world_LeaveRequest,
        __Marshaller_world_LeaveResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::World.RoomReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Room</summary>
    [grpc::BindServiceMethod(typeof(Room), "BindService")]
    public abstract partial class RoomBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::World.JoinResponse> Join(global::World.JoinRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::World.SyncResponse> Sync(global::World.SyncRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::World.LeaveResponse> Leave(global::World.LeaveRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Room</summary>
    public partial class RoomClient : grpc::ClientBase<RoomClient>
    {
      /// <summary>Creates a new client for Room</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public RoomClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Room that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public RoomClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected RoomClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected RoomClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::World.JoinResponse Join(global::World.JoinRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Join(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::World.JoinResponse Join(global::World.JoinRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Join, null, options, request);
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::World.JoinResponse> JoinAsync(global::World.JoinRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return JoinAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::World.JoinResponse> JoinAsync(global::World.JoinRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Join, null, options, request);
      }
      public virtual global::World.SyncResponse Sync(global::World.SyncRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Sync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::World.SyncResponse Sync(global::World.SyncRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Sync, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::World.SyncResponse> SyncAsync(global::World.SyncRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SyncAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::World.SyncResponse> SyncAsync(global::World.SyncRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Sync, null, options, request);
      }
      public virtual global::World.LeaveResponse Leave(global::World.LeaveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Leave(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::World.LeaveResponse Leave(global::World.LeaveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Leave, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::World.LeaveResponse> LeaveAsync(global::World.LeaveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LeaveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::World.LeaveResponse> LeaveAsync(global::World.LeaveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Leave, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override RoomClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new RoomClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RoomBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Join, serviceImpl.Join)
          .AddMethod(__Method_Sync, serviceImpl.Sync)
          .AddMethod(__Method_Leave, serviceImpl.Leave).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, RoomBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Join, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::World.JoinRequest, global::World.JoinResponse>(serviceImpl.Join));
      serviceBinder.AddMethod(__Method_Sync, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::World.SyncRequest, global::World.SyncResponse>(serviceImpl.Sync));
      serviceBinder.AddMethod(__Method_Leave, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::World.LeaveRequest, global::World.LeaveResponse>(serviceImpl.Leave));
    }

  }
}
#endregion
