using System;

namespace CP.Client.Core.Common.ConectivityToApi
{
    public sealed class ConnectivityState
            : IConnectivityState
            , IConnectivityReporter
    {
        private ConnectivityStatus _current = ConnectivityStatus.Offline;

        public ConnectivityStatus Current => _current;

        public bool IsOnline  => _current == ConnectivityStatus.Online;
        public bool IsOffline => _current == ConnectivityStatus.Offline;

        public event EventHandler<ConnectivityStatus>? ConnectivityChanged;

        void IConnectivityReporter.ReportOnline()
            => SetState(ConnectivityStatus.Online);

        void IConnectivityReporter.ReportOffline(Exception cause)
            => SetState(ConnectivityStatus.Offline);

        private void SetState(ConnectivityStatus next)
        {
            if (_current == next)
                return;

            _current = next;
            ConnectivityChanged?.Invoke(this, _current);
        }
    }

}