﻿using VpnHood.Common;
using VpnHood.Common.Utils;

namespace VpnHood.Client.App.ClientProfiles;

public class ClientProfileInfo(ClientProfile clientProfile)
    : ClientProfileBaseInfo(clientProfile)
{
    public string TokenId { get; private set; } = clientProfile.Token.TokenId;
    public string[] HostNames { get; private set; } = GetEndPoints(clientProfile.Token.ServerToken);
    public bool IsValidHostName { get; private set; } = clientProfile.Token.ServerToken.IsValidHostName;
    public bool IsBuiltIn { get; private set; } = clientProfile.IsBuiltIn;
    public bool IsForAccount { get; private set; } = clientProfile.IsForAccount;
    public ClientServerLocationInfo[] ServerLocationInfos { get; private set; } = clientProfile.ServerLocationInfos;

    private static string[] GetEndPoints(ServerToken serverToken)
    {
        var hostNames = new List<string>();
        if (serverToken.IsValidHostName)
            hostNames.Add(VhUtil.RedactHostName(serverToken.HostName));

        if (serverToken.HostEndPoints != null)
            hostNames.AddRange(serverToken.HostEndPoints.Select(x => VhUtil.RedactIpAddress(x.Address)));

        return hostNames.ToArray();
    }
}