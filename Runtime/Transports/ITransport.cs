using System.Collections.Generic;

namespace UnilogTransports
{
  public interface ITransport
  {
    public void SendAsync(LogLevel level, string message, IEnumerable<string> tags, Dictionary<string, object> keyValue);
  }
}