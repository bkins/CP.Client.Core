using System;

namespace CP.Client.Core.Common.ConnectivityToApi
{
    public interface IConnectivityState
    {
        ConnectivityStatus Current { get; }

        bool IsOnline  { get; }
        bool IsOffline { get; }

        event EventHandler<ConnectivityStatus>? ConnectivityChanged;
    }
}