using System;
using System.Collections.Generic;
using UnityEngine;

/*

Graylog example:
curl -XPOST -v http://127.0.0.1:12202/gelf -p0 \
-d $'{"short_message":"Bulk message 1", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 2", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 3", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 4", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 5", "host":"example.org", "facility":"test", "_foo":"bar"}'

*/

namespace UnilogTransports
{
  [Serializable]
  public class GrayLog: ITransport
  {
    [SerializeField]
    private string _url;
    public Dictionary<string, object> DefaultKeyValuePairs = new Dictionary<string, object>();

    public GrayLog(string url)
    {
      _url = url;
    }
    public async void SendAsync(LogLevel level, string message, IEnumerable<string> tags, Dictionary<string, object> keyValue)
    {
      // Sending message to graylog2 server 
      // Don't forget about default key/value pairs
      
    }
  }
}