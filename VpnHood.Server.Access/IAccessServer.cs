﻿using System;
using System.Net;
using System.Threading.Tasks;
using VpnHood.Common.Messaging;
using VpnHood.Server.Messaging;

namespace VpnHood.Server
{
    public interface IAccessServer : IDisposable
    {
        bool IsMaintenanceMode { get; }
        Task<SessionResponseEx> Session_Create(SessionRequestEx sessionRequestEx);
        Task<SessionResponseEx> Session_Get(uint sessionId, IPEndPoint hostEndPoint, IPAddress? clientIp);
        Task<ResponseBase> Session_AddUsage(uint sessionId, bool closeSession, UsageInfo usageInfo);
        Task<ServerCommand> Server_UpdateStatus(ServerStatus serverStatus);
        Task<ServerConfig> Server_Configure(ServerInfo serverInfo);
        Task<byte[]> GetSslCertificateData(IPEndPoint hostEndPoint);
    }
}