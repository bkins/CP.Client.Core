using System.Collections.Generic;
using System.Threading;

namespace CP.Client.Core.Telemetry;

public interface ITelemetryStreamClient
{
    IAsyncEnumerable<TelemetryEventDto> SubscribeAsync(string baseApiUrl, CancellationToken cancellationToken = default);
}
