using System.Collections.Generic;

/*

Graylog example:
curl -XPOST -v http://127.0.0.1:12202/gelf -p0 \
-d $'{"short_message":"Bulk message 1", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 2", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 3", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 4", "host":"example.org", "facility":"test", "_foo":"bar"}\r\n\
{"short_message":"Bulk message 5", "host":"example.org", "facility":"test", "_foo":"bar"}'

*/

namespace Transports
{
  public interface ITransport
  {
    public void Send(LogLevel level, string message, Dictionary<string, object> keyValue);
  }
  public class GrayLog2
  {
    public string ServerUrl;
    public Dictionary<string, object> DefaultKeyValuePairs = new Dictionary<string, object>();

    public GrayLog2(string url)
    {
      ServerUrl = url;
    }
    public void Send(LogLevel level, string message, Dictionary<string, object> keyValue)
    {
      // Sending message to graylog2 server 
      // Don't forget about default key/value pairs

    }
  }
}