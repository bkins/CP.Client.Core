using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CP.Client.Core.Telemetry;

public sealed class TelemetryStreamClient : ITelemetryStreamClient
{
    private readonly HttpClient                   _httpClient;
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
                                                                      {
                                                                          PropertyNameCaseInsensitive = true
                                                                      };

    public TelemetryStreamClient(HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
    }

    public async IAsyncEnumerable<TelemetryEventDto> SubscribeAsync(string baseApiUrl, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var endpoint = $"{baseApiUrl.TrimEnd('/')}/api/system/telemetry/stream";
        using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/event-stream"));

        using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                                              .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync()
                                                 .ConfigureAwait(false);
        using var reader = new StreamReader(stream);

        while (!cancellationToken.IsCancellationRequested)
        {
            var line = await reader.ReadLineAsync()
                                   .ConfigureAwait(false);

            if (line is null) break;
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            {
                var json = line.Substring(5).Trim();
                if (string.IsNullOrWhiteSpace(json)) continue;

                TelemetryEventDto? eventDto = null;
                try
                {
                    eventDto = JsonSerializer.Deserialize<TelemetryEventDto>(json, SerializerOptions);
                }
                catch
                {
                    // Ignore malformed individual frames
                }

                if (eventDto is not null)
                {
                    yield return eventDto;
                }
            }
        }
    }
}
