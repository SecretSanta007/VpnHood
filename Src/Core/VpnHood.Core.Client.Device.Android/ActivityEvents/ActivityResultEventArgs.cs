﻿using Android.Content;

namespace VpnHood.Core.Client.Device.Droid.ActivityEvents;

public class ActivityResultEventArgs : EventArgs
{
    public int RequestCode { get; init; }

    public Result ResultCode { get; init; }

    public Intent? Data { get; init; }
}