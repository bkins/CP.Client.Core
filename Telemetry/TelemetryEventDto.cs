using System;
using System.Collections.Generic;

namespace CP.Client.Core.Telemetry;

public sealed class TelemetryEventDto
{
    public Guid                       EventId      { get; set; } = Guid.NewGuid();
    public string                     EventName    { get; set; } = string.Empty;
    public string                     SessionId    { get; set; } = string.Empty;
    public DateTime                   TimestampUtc { get; set; } = DateTime.UtcNow;
    public double                     DurationMs   { get; set; }
    public bool                       Success      { get; set; }
    public Dictionary<string, object> Properties   { get; set; } = new();
}
