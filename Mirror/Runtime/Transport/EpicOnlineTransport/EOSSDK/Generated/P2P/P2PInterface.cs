// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.P2P
{
	public sealed partial class P2PInterface : Handle
	{
		public P2PInterface()
		{
		}

		public P2PInterface(System.IntPtr innerHandle) : base(innerHandle)
		{
		}

		/// <summary>
		/// The most recent version of the <see cref="AcceptConnection" /> API.
		/// </summary>
		public const int AcceptconnectionApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="AddNotifyIncomingPacketQueueFull" /> API.
		/// </summary>
		public const int AddnotifyincomingpacketqueuefullApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="AddNotifyPeerConnectionClosed" /> API.
		/// </summary>
		public const int AddnotifypeerconnectionclosedApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="AddNotifyPeerConnectionEstablished" /> API.
		/// </summary>
		public const int AddnotifypeerconnectionestablishedApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="AddNotifyPeerConnectionRequest" /> API.
		/// </summary>
		public const int AddnotifypeerconnectionrequestApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="ClearPacketQueue" /> API.
		/// </summary>
		public const int ClearpacketqueueApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CloseConnection" /> API.
		/// </summary>
		public const int CloseconnectionApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CloseConnections" /> API.
		/// </summary>
		public const int CloseconnectionsApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetNATType" /> API.
		/// </summary>
		public const int GetnattypeApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetNextReceivedPacketSize" /> API.
		/// </summary>
		public const int GetnextreceivedpacketsizeApiLatest = 2;

		/// <summary>
		/// The most recent version of the <see cref="GetPacketQueueInfo" /> API.
		/// </summary>
		public const int GetpacketqueueinfoApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetPortRange" /> API.
		/// </summary>
		public const int GetportrangeApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetRelayControl" /> API.
		/// </summary>
		public const int GetrelaycontrolApiLatest = 1;

		/// <summary>
		/// The maximum amount of unique Socket ID connections that can be opened with each remote user. As this limit is only per remote user, you may have more
		/// than this number of Socket IDs across multiple remote users.
		/// </summary>
		public const int MaxConnections = 32;

		/// <summary>
		/// A packet's maximum size in bytes
		/// </summary>
		public const int MaxPacketSize = 1170;

		/// <summary>
		/// Helper constant to signify that the packet queue is allowed to grow indefinitely
		/// </summary>
		public const int MaxQueueSizeUnlimited = 0;

		/// <summary>
		/// The most recent version of the <see cref="QueryNATType" /> API.
		/// </summary>
		public const int QuerynattypeApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="ReceivePacket" /> API.
		/// </summary>
		public const int ReceivepacketApiLatest = 2;

		/// <summary>
		/// The most recent version of the <see cref="SendPacket" /> API.
		/// </summary>
		public const int SendpacketApiLatest = 2;

		/// <summary>
		/// The most recent version of the <see cref="SetPacketQueueSize" /> API.
		/// </summary>
		public const int SetpacketqueuesizeApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="SetPortRange" /> API.
		/// </summary>
		public const int SetportrangeApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="SetRelayControl" /> API.
		/// </summary>
		public const int SetrelaycontrolApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="SocketId" /> structure.
		/// </summary>
		public const int SocketidApiLatest = 1;

		/// <summary>
		/// Accept connections from a specific peer. If this peer has not attempted to connect yet, when they do, they will automatically be accepted.
		/// </summary>
		/// <param name="options">Information about who would like to accept a connection, and which connection</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the provided data is valid
		/// <see cref="Result.InvalidParameters" /> - if the provided data is invalid
		/// </returns>
		public Result AcceptConnection(ref AcceptConnectionOptions options)
		{
			AcceptConnectionOptionsInternal optionsInternal = new AcceptConnectionOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_AcceptConnection(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Listen for when our packet queue has become full. This event gives an opportunity to read packets to make
		/// room for new incoming packets. If this event fires and no packets are read by calling <see cref="ReceivePacket" />
		/// or the packet queue size is not increased by <see cref="SetPacketQueueSize" />, any packets that are received after
		/// this event are discarded until there is room again in the queue.
		/// </summary>
		/// <param name="options">Information about what version of the <see cref="AddNotifyIncomingPacketQueueFull" /> API is supported</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="incomingPacketQueueFullHandler">The callback to be fired when the incoming packet queue is full</param>
		/// <returns>
		/// A valid notification ID if successfully bound, or <see cref="Common.InvalidNotificationid" /> otherwise
		/// </returns>
		public ulong AddNotifyIncomingPacketQueueFull(ref AddNotifyIncomingPacketQueueFullOptions options, object clientData, OnIncomingPacketQueueFullCallback incomingPacketQueueFullHandler)
		{
			AddNotifyIncomingPacketQueueFullOptionsInternal optionsInternal = new AddNotifyIncomingPacketQueueFullOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var incomingPacketQueueFullHandlerInternal = new OnIncomingPacketQueueFullCallbackInternal(OnIncomingPacketQueueFullCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, incomingPacketQueueFullHandler, incomingPacketQueueFullHandlerInternal);

			var funcResult = Bindings.EOS_P2P_AddNotifyIncomingPacketQueueFull(InnerHandle, ref optionsInternal, clientDataAddress, incomingPacketQueueFullHandlerInternal);

			Helper.Dispose(ref optionsInternal);

			Helper.AssignNotificationIdToCallback(clientDataAddress, funcResult);

			return funcResult;
		}

		/// <summary>
		/// Listen for when a previously opened connection is closed.
		/// </summary>
		/// <param name="options">Information about who would like notifications about closed connections, and for which socket</param>
		/// <param name="clientData">This value is returned to the caller when ConnectionClosedHandler is invoked</param>
		/// <param name="connectionClosedHandler">The callback to be fired when an open connection has been closed</param>
		/// <returns>
		/// A valid notification ID if successfully bound, or <see cref="Common.InvalidNotificationid" /> otherwise
		/// </returns>
		public ulong AddNotifyPeerConnectionClosed(ref AddNotifyPeerConnectionClosedOptions options, object clientData, OnRemoteConnectionClosedCallback connectionClosedHandler)
		{
			AddNotifyPeerConnectionClosedOptionsInternal optionsInternal = new AddNotifyPeerConnectionClosedOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var connectionClosedHandlerInternal = new OnRemoteConnectionClosedCallbackInternal(OnRemoteConnectionClosedCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, connectionClosedHandler, connectionClosedHandlerInternal);

			var funcResult = Bindings.EOS_P2P_AddNotifyPeerConnectionClosed(InnerHandle, ref optionsInternal, clientDataAddress, connectionClosedHandlerInternal);

			Helper.Dispose(ref optionsInternal);

			Helper.AssignNotificationIdToCallback(clientDataAddress, funcResult);

			return funcResult;
		}

		/// <summary>
		/// Listen for when a connection is established.
		/// </summary>
		/// <param name="options">Information about who would like notifications about established connections, and for which socket</param>
		/// <param name="clientData">This value is returned to the caller when ConnectionEstablishedHandler is invoked</param>
		/// <param name="connectionEstablishedHandler">The callback to be fired when a connection has been established</param>
		/// <returns>
		/// A valid notification ID if successfully bound, or <see cref="Common.InvalidNotificationid" /> otherwise
		/// </returns>
		public ulong AddNotifyPeerConnectionEstablished(ref AddNotifyPeerConnectionEstablishedOptions options, object clientData, OnPeerConnectionEstablishedCallback connectionEstablishedHandler)
		{
			AddNotifyPeerConnectionEstablishedOptionsInternal optionsInternal = new AddNotifyPeerConnectionEstablishedOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var connectionEstablishedHandlerInternal = new OnPeerConnectionEstablishedCallbackInternal(OnPeerConnectionEstablishedCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, connectionEstablishedHandler, connectionEstablishedHandlerInternal);

			var funcResult = Bindings.EOS_P2P_AddNotifyPeerConnectionEstablished(InnerHandle, ref optionsInternal, clientDataAddress, connectionEstablishedHandlerInternal);

			Helper.Dispose(ref optionsInternal);

			Helper.AssignNotificationIdToCallback(clientDataAddress, funcResult);

			return funcResult;
		}

		/// <summary>
		/// Listen for incoming connection requests on a particular Socket ID, or optionally all Socket IDs. The bound function
		/// will only be called if the connection has not already been accepted.
		/// </summary>
		/// <param name="options">Information about who would like notifications, and (optionally) only for a specific socket</param>
		/// <param name="clientData">This value is returned to the caller when ConnectionRequestHandler is invoked</param>
		/// <param name="connectionRequestHandler">The callback to be fired when we receive a connection request</param>
		/// <returns>
		/// A valid notification ID if successfully bound, or <see cref="Common.InvalidNotificationid" /> otherwise
		/// </returns>
		public ulong AddNotifyPeerConnectionRequest(ref AddNotifyPeerConnectionRequestOptions options, object clientData, OnIncomingConnectionRequestCallback connectionRequestHandler)
		{
			AddNotifyPeerConnectionRequestOptionsInternal optionsInternal = new AddNotifyPeerConnectionRequestOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var connectionRequestHandlerInternal = new OnIncomingConnectionRequestCallbackInternal(OnIncomingConnectionRequestCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, connectionRequestHandler, connectionRequestHandlerInternal);

			var funcResult = Bindings.EOS_P2P_AddNotifyPeerConnectionRequest(InnerHandle, ref optionsInternal, clientDataAddress, connectionRequestHandlerInternal);

			Helper.Dispose(ref optionsInternal);

			Helper.AssignNotificationIdToCallback(clientDataAddress, funcResult);

			return funcResult;
		}

		/// <summary>
		/// Clear queued incoming and outgoing packets.
		/// </summary>
		/// <param name="options">Information about which queues should be cleared</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the input options were valid (even if queues were empty and no packets where cleared)
		/// <see cref="Result.IncompatibleVersion" /> - if wrong API version
		/// <see cref="Result.InvalidUser" /> - if wrong local and/or remote user
		/// <see cref="Result.InvalidParameters" /> - if input was invalid in other way
		/// </returns>
		public Result ClearPacketQueue(ref ClearPacketQueueOptions options)
		{
			ClearPacketQueueOptionsInternal optionsInternal = new ClearPacketQueueOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_ClearPacketQueue(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Stop accepting new connections from a specific peer and close any open connections.
		/// </summary>
		/// <param name="options">Information about who would like to close a connection, and which connection.</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the provided data is valid
		/// <see cref="Result.InvalidParameters" /> - if the provided data is invalid
		/// </returns>
		public Result CloseConnection(ref CloseConnectionOptions options)
		{
			CloseConnectionOptionsInternal optionsInternal = new CloseConnectionOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_CloseConnection(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Close any open Connections for a specific Peer Connection ID.
		/// </summary>
		/// <param name="options">Information about who would like to close connections, and by what socket ID</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the provided data is valid
		/// <see cref="Result.InvalidParameters" /> - if the provided data is invalid
		/// </returns>
		public Result CloseConnections(ref CloseConnectionsOptions options)
		{
			CloseConnectionsOptionsInternal optionsInternal = new CloseConnectionsOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_CloseConnections(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Get our last-queried NAT-type, if it has been successfully queried.
		/// </summary>
		/// <param name="options">Information about what version of the <see cref="GetNATType" /> API is supported</param>
		/// <param name="outNATType">The queried NAT Type, or unknown if unknown</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if we have cached data
		/// <see cref="Result.NotFound" /> - If we do not have queried data cached
		/// </returns>
		public Result GetNATType(ref GetNATTypeOptions options, out NATType outNATType)
		{
			GetNATTypeOptionsInternal optionsInternal = new GetNATTypeOptionsInternal();
			optionsInternal.Set(ref options);

			outNATType = Helper.GetDefault<NATType>();

			var funcResult = Bindings.EOS_P2P_GetNATType(InnerHandle, ref optionsInternal, ref outNATType);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Gets the size of the packet that will be returned by ReceivePacket for a particular user, if there is any available
		/// packets to be retrieved.
		/// </summary>
		/// <param name="options">Information about who is requesting the size of their next packet</param>
		/// <param name="outPacketSizeBytes">The amount of bytes required to store the data of the next packet for the requested user</param>
		/// <returns>
		/// <see cref="Result.Success" /> - If OutPacketSizeBytes was successfully set and there is data to be received
		/// <see cref="Result.InvalidParameters" /> - If input was invalid
		/// <see cref="Result.NotFound" /> - If there are no packets available for the requesting user
		/// </returns>
		public Result GetNextReceivedPacketSize(ref GetNextReceivedPacketSizeOptions options, out uint outPacketSizeBytes)
		{
			GetNextReceivedPacketSizeOptionsInternal optionsInternal = new GetNextReceivedPacketSizeOptionsInternal();
			optionsInternal.Set(ref options);

			outPacketSizeBytes = Helper.GetDefault<uint>();

			var funcResult = Bindings.EOS_P2P_GetNextReceivedPacketSize(InnerHandle, ref optionsInternal, ref outPacketSizeBytes);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Gets the current cached information related to the incoming and outgoing packet queues.
		/// </summary>
		/// <param name="options">Information about what version of the <see cref="GetPacketQueueInfo" /> API is supported</param>
		/// <param name="outPacketQueueInfo">The current information of the incoming and outgoing packet queues</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the input options were valid
		/// <see cref="Result.InvalidParameters" /> - if the input was invalid in some way
		/// </returns>
		public Result GetPacketQueueInfo(ref GetPacketQueueInfoOptions options, out PacketQueueInfo outPacketQueueInfo)
		{
			GetPacketQueueInfoOptionsInternal optionsInternal = new GetPacketQueueInfoOptionsInternal();
			optionsInternal.Set(ref options);

			var outPacketQueueInfoInternal = Helper.GetDefault<PacketQueueInfoInternal>();

			var funcResult = Bindings.EOS_P2P_GetPacketQueueInfo(InnerHandle, ref optionsInternal, ref outPacketQueueInfoInternal);

			Helper.Dispose(ref optionsInternal);

			Helper.Get(ref outPacketQueueInfoInternal, out outPacketQueueInfo);

			return funcResult;
		}

		/// <summary>
		/// Get the current chosen port and the amount of other ports to try above the chosen port if the chosen port is unavailable.
		/// </summary>
		/// <param name="options">Information about what version of the <see cref="GetPortRange" /> API is supported</param>
		/// <param name="outPort">The port that will be tried first</param>
		/// <param name="outNumAdditionalPortsToTry">The amount of ports to try above the value in OutPort, if OutPort is unavailable</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the input options were valid
		/// <see cref="Result.InvalidParameters" /> - if the input was invalid in some way
		/// </returns>
		public Result GetPortRange(ref GetPortRangeOptions options, out ushort outPort, out ushort outNumAdditionalPortsToTry)
		{
			GetPortRangeOptionsInternal optionsInternal = new GetPortRangeOptionsInternal();
			optionsInternal.Set(ref options);

			outPort = Helper.GetDefault<ushort>();

			outNumAdditionalPortsToTry = Helper.GetDefault<ushort>();

			var funcResult = Bindings.EOS_P2P_GetPortRange(InnerHandle, ref optionsInternal, ref outPort, ref outNumAdditionalPortsToTry);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Get the current relay control setting.
		/// </summary>
		/// <param name="options">Information about what version of the <see cref="GetRelayControl" /> API is supported</param>
		/// <param name="outRelayControl">The relay control setting currently configured</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the input was valid
		/// <see cref="Result.InvalidParameters" /> - if the input was invalid in some way
		/// </returns>
		public Result GetRelayControl(ref GetRelayControlOptions options, out RelayControl outRelayControl)
		{
			GetRelayControlOptionsInternal optionsInternal = new GetRelayControlOptionsInternal();
			optionsInternal.Set(ref options);

			outRelayControl = Helper.GetDefault<RelayControl>();

			var funcResult = Bindings.EOS_P2P_GetRelayControl(InnerHandle, ref optionsInternal, ref outRelayControl);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Query the current NAT-type of our connection.
		/// </summary>
		/// <param name="options">Information about what version of the <see cref="QueryNATType" /> API is supported</param>
		/// <param name="clientData">arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="completionDelegate">The callback to be fired when we finish querying our NAT type</param>
		public void QueryNATType(ref QueryNATTypeOptions options, object clientData, OnQueryNATTypeCompleteCallback completionDelegate)
		{
			QueryNATTypeOptionsInternal optionsInternal = new QueryNATTypeOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnQueryNATTypeCompleteCallbackInternal(OnQueryNATTypeCompleteCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_P2P_QueryNATType(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		/// <summary>
		/// Receive the next packet for the local user, and information associated with this packet, if it exists.
		/// </summary>
		/// <param name="options">Information about who is requesting the size of their next packet, and how much data can be stored safely</param>
		/// <param name="outPeerId">The Remote User who sent data. Only set if there was a packet to receive.</param>
		/// <param name="outSocketId">The Socket ID of the data that was sent. Only set if there was a packet to receive.</param>
		/// <param name="outChannel">The channel the data was sent on. Only set if there was a packet to receive.</param>
		/// <param name="outData">Buffer to store the data being received. Must be at least <see cref="GetNextReceivedPacketSize" /> in length or data will be truncated</param>
		/// <param name="outBytesWritten">The amount of bytes written to OutData. Only set if there was a packet to receive.</param>
		/// <returns>
		/// <see cref="Result.Success" /> - If the packet was received successfully
		/// <see cref="Result.InvalidParameters" /> - If input was invalid
		/// <see cref="Result.NotFound" /> - If there are no packets available for the requesting user
		/// </returns>
		public Result ReceivePacket(ref ReceivePacketOptions options, out ProductUserId outPeerId, out SocketId outSocketId, out byte outChannel, System.ArraySegment<byte> outData, out uint outBytesWritten)
		{
			ReceivePacketOptionsInternal optionsInternal = new ReceivePacketOptionsInternal();
			optionsInternal.Set(ref options);

			var outPeerIdAddress = System.IntPtr.Zero;

			var outSocketIdInternal = Helper.GetDefault<SocketIdInternal>();

			outChannel = Helper.GetDefault<byte>();

			outBytesWritten = 0;
			System.IntPtr outDataAddress = Helper.AddPinnedBuffer(outData);

			var funcResult = Bindings.EOS_P2P_ReceivePacket(InnerHandle, ref optionsInternal, ref outPeerIdAddress, ref outSocketIdInternal, ref outChannel, outDataAddress, ref outBytesWritten);

			Helper.Dispose(ref optionsInternal);

			Helper.Get(outPeerIdAddress, out outPeerId);

			Helper.Get(ref outSocketIdInternal, out outSocketId);

			Helper.Dispose(ref outDataAddress);

			return funcResult;
		}

		/// <summary>
		/// Stop listening for full incoming packet queue events on a previously bound handler.
		/// </summary>
		/// <param name="notificationId">The previously bound notification ID</param>
		public void RemoveNotifyIncomingPacketQueueFull(ulong notificationId)
		{
			Bindings.EOS_P2P_RemoveNotifyIncomingPacketQueueFull(InnerHandle, notificationId);

			Helper.RemoveCallbackByNotificationId(notificationId);
		}

		/// <summary>
		/// Stop notifications for connections being closed on a previously bound handler.
		/// </summary>
		/// <param name="notificationId">The previously bound notification ID</param>
		public void RemoveNotifyPeerConnectionClosed(ulong notificationId)
		{
			Bindings.EOS_P2P_RemoveNotifyPeerConnectionClosed(InnerHandle, notificationId);

			Helper.RemoveCallbackByNotificationId(notificationId);
		}

		/// <summary>
		/// Stop notifications for connections being established on a previously bound handler.
		/// </summary>
		/// <param name="notificationId">The previously bound notification ID</param>
		public void RemoveNotifyPeerConnectionEstablished(ulong notificationId)
		{
			Bindings.EOS_P2P_RemoveNotifyPeerConnectionEstablished(InnerHandle, notificationId);

			Helper.RemoveCallbackByNotificationId(notificationId);
		}

		/// <summary>
		/// Stop listening for connection requests on a previously bound handler.
		/// </summary>
		/// <param name="notificationId">The previously bound notification ID</param>
		public void RemoveNotifyPeerConnectionRequest(ulong notificationId)
		{
			Bindings.EOS_P2P_RemoveNotifyPeerConnectionRequest(InnerHandle, notificationId);

			Helper.RemoveCallbackByNotificationId(notificationId);
		}

		/// <summary>
		/// Send a packet to a peer at the specified address. If there is already an open connection to this peer, it will be
		/// sent immediately. If there is no open connection, an attempt to connect to the peer will be made. An <see cref="Result.Success" />
		/// result only means the data was accepted to be sent, not that it has been successfully delivered to the peer.
		/// </summary>
		/// <param name="options">Information about the data being sent, by who, to who</param>
		/// <returns>
		/// <see cref="Result.Success" /> - If packet was queued to be sent successfully
		/// <see cref="Result.InvalidParameters" /> - If input was invalid
		/// <see cref="Result.LimitExceeded" /> - If amount of data being sent is too large, or the outgoing packet queue was full
		/// </returns>
		public Result SendPacket(ref SendPacketOptions options)
		{
			SendPacketOptionsInternal optionsInternal = new SendPacketOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_SendPacket(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Sets the maximum packet queue sizes that packets waiting to be sent or received can use. If the packet queue
		/// size is made smaller than the current queue size while there are packets in the queue that would push this
		/// packet size over, existing packets are kept but new packets may not be added to the full queue until enough
		/// packets are sent or received.
		/// </summary>
		/// <param name="options">Information about packet queue size</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the input options were valid
		/// <see cref="Result.InvalidParameters" /> - if the input was invalid in some way
		/// </returns>
		public Result SetPacketQueueSize(ref SetPacketQueueSizeOptions options)
		{
			SetPacketQueueSizeOptionsInternal optionsInternal = new SetPacketQueueSizeOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_SetPacketQueueSize(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Set configuration options related to network ports.
		/// </summary>
		/// <param name="options">Information about network ports config options</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the options were set successfully
		/// <see cref="Result.InvalidParameters" /> - if the options are invalid in some way
		/// </returns>
		public Result SetPortRange(ref SetPortRangeOptions options)
		{
			SetPortRangeOptionsInternal optionsInternal = new SetPortRangeOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_SetPortRange(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Set how relay servers are to be used. This setting does not immediately apply to existing connections, but may apply to existing
		/// connections if the connection requires renegotiation.
		/// <seealso cref="RelayControl" />
		/// </summary>
		/// <param name="options">Information about relay server config options</param>
		/// <returns>
		/// <see cref="Result.Success" /> - if the options were set successfully
		/// <see cref="Result.InvalidParameters" /> - if the options are invalid in some way
		/// </returns>
		public Result SetRelayControl(ref SetRelayControlOptions options)
		{
			SetRelayControlOptionsInternal optionsInternal = new SetRelayControlOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_P2P_SetRelayControl(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		[MonoPInvokeCallback(typeof(OnIncomingConnectionRequestCallbackInternal))]
		internal static void OnIncomingConnectionRequestCallbackInternalImplementation(ref OnIncomingConnectionRequestInfoInternal data)
		{
			OnIncomingConnectionRequestCallback callback;
			OnIncomingConnectionRequestInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnIncomingPacketQueueFullCallbackInternal))]
		internal static void OnIncomingPacketQueueFullCallbackInternalImplementation(ref OnIncomingPacketQueueFullInfoInternal data)
		{
			OnIncomingPacketQueueFullCallback callback;
			OnIncomingPacketQueueFullInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnPeerConnectionEstablishedCallbackInternal))]
		internal static void OnPeerConnectionEstablishedCallbackInternalImplementation(ref OnPeerConnectionEstablishedInfoInternal data)
		{
			OnPeerConnectionEstablishedCallback callback;
			OnPeerConnectionEstablishedInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnQueryNATTypeCompleteCallbackInternal))]
		internal static void OnQueryNATTypeCompleteCallbackInternalImplementation(ref OnQueryNATTypeCompleteInfoInternal data)
		{
			OnQueryNATTypeCompleteCallback callback;
			OnQueryNATTypeCompleteInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnRemoteConnectionClosedCallbackInternal))]
		internal static void OnRemoteConnectionClosedCallbackInternalImplementation(ref OnRemoteConnectionClosedInfoInternal data)
		{
			OnRemoteConnectionClosedCallback callback;
			OnRemoteConnectionClosedInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}
	}
}