using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnilogTransports
{
  [Serializable]
  public class GrayLog : ITransport
  {

    [SerializeField]
    private Graylog.Options _options;

    [SerializeField]
    public Dictionary<string, object> AdditionalFields = new Dictionary<string, object>();

    private Graylog.IGELFClient _client;

    public GrayLog(string host, int port)
    {
      _options = new Graylog.Options()
      {
        Port = port,
        Host = host,
        Protocol = Graylog.Protocol.Http
      };
      InitClient();
    }
    public GrayLog(Graylog.Options options)
    {
      _options = options;
      InitClient();
    }
    private void InitClient()
    {
      if (_options.Protocol == Graylog.Protocol.Http)
      {
        _client = new Graylog.HttpGelfClient(_options);
      }
      if (_options.Protocol == Graylog.Protocol.Udp)
      {
        _client = new Graylog.UdpGelfClient(_options);
      }
    }

    public void SendAsync(LogLevel level, string message, IEnumerable<string> tags, Dictionary<string, object> keyValue)
    {
      if (_options == null)
      {
        Debug.LogError("Graylog is not properly configured");
      }

      _client.SendMessageAsync(new Graylog.GELFMessage()
      {
        ShortMessage = message,
        Level = level,
        Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000,
        AdditionalFields = keyValue,
        Tags = tags,
      });
    }
  }
}