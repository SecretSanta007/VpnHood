﻿namespace VpnHood.Common.Exceptions;

public class AdLoadException : Exception
{
    public AdLoadException(string message) : base(message)
    {
    }

    public AdLoadException(string message, Exception innerException) : base(message, innerException)
    {
    }
}