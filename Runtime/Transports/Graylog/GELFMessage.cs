using System;
using System.Collections.Generic;

namespace UnilogTransports.Graylog
{
    // https://docs.graylog.org/en/3.1/pages/gelf.html#gelf-payload-specification
    public class GELFMessage
    {
        public string Version { get; } = "1.1";

        public string? Host { get; set; }

        public string? ShortMessage { get; set; }

        public double Timestamp { get; set; }

        public LogLevel Level { get; set; }

        public string? Logger { get; set; }

        public string? Exception { get; set; }

        public int? EventId { get; set; }

        public string? EventName { get; set; }

        public IReadOnlyCollection<KeyValuePair<string, object>> AdditionalFields { get; set; } =
            Array.Empty<KeyValuePair<string, object>>();
    }
}