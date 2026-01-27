using System;

namespace CP.Client.Core.Common.ConectivityToApi
{
    public interface IConnectivityReporter
    {
        void ReportOnline();
        void ReportOffline(Exception cause);
    }
}