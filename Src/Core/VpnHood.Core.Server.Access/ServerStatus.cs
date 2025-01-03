﻿using VpnHood.Core.Common.Messaging;
using VpnHood.Core.Server.Access.Messaging;

namespace VpnHood.Core.Server.Access;

public class ServerStatus
{
    public int SessionCount { get; set; }
    public int TcpConnectionCount { get; set; }
    public int UdpConnectionCount { get; set; }
    public long? AvailableMemory { get; set; }
    public long? TotalSwapMemory { get; set; }
    public long? AvailableSwapMemory { get; set; }
    public string? TcpCongestionControl { get; set; }
    public int? CpuUsage { get; set; }
    public long UsedMemory { get; set; }
    public int ThreadCount { get; set; }
    public Traffic TunnelSpeed { get; set; } = new();
    public string? ConfigCode { get; set; }
    public string? ConfigError { get; set; }
    public SessionUsage[] SessionUsages { get; set; } = [];
}