using System;

namespace CP.Client.Core.Common.ConnectivityToApi
{
    public interface IConnectivityReporter
    {
        bool Online();
        void ReportOnline();
        void ReportOffline(Exception cause);
        void ReportOffline(string    cause);
    }
}