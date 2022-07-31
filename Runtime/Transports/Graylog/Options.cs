using System;
using System.Collections.Generic;

namespace UnilogTransports.Graylog
{
    public class Options
    {
        /// <summary>
        ///     Enable/disable additional fields added via log scopes.
        /// </summary>
        public bool IncludeScopes { get; set; } = true;

        /// <summary>
        ///     Protocol used to send logs.
        /// </summary>
        public Protocol Protocol { get; set; } = Protocol.Udp;

        /// <summary>
        ///     GELF server host.
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        ///     GELF server port.
        /// </summary>
        public int Port { get; set; } = 12201;

        /// <summary>
        ///     Log source name mapped to the GELF host field (required).
        /// </summary>
        public string? LogSource { get; set; }

        /// <summary>
        ///     Enable GZip message compression for UDP logging.
        /// </summary>
        public bool CompressUdp { get; set; } = true;

        /// <summary>
        ///     The UDP message size in bytes under which messages will not be compressed.
        /// </summary>
        public int UdpCompressionThreshold { get; set; } = 512;

        /// <summary>
        ///     The UDP message max size in bytes to be sent in one datagram.
        /// </summary>
        public int UdpMaxChunkSize { get; set; } = 8192;

        /// <summary>
        ///     Additional fields that will be attached to all log messages.
        /// </summary>
        public Dictionary<string, object> AdditionalFields { get; set; } = new();

        /// <summary>
        ///     Headers used when sending logs via HTTP(S).
        /// </summary>
        public Dictionary<string, string> HttpHeaders { get; set; } = new();

        /// <summary>
        ///     Timeout used when sending logs via HTTP(S).
        /// </summary>
        public TimeSpan HttpTimeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        ///     Include a field with the original message template before structured log parameters are replaced.
        /// </summary>
        public bool IncludeMessageTemplates { get; set; }
    }
}