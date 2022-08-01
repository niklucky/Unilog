using System;
using System.Collections.Generic;

namespace UnilogTransports.Graylog
{
  // https://docs.graylog.org/en/3.1/pages/gelf.html#gelf-payload-specification
  [Serializable]
  public class GELFMessage
  {
    public string Version = "1.1";

    public string Host = "localhost";

    public string ShortMessage;

    public double Timestamp;

    public LogLevel Level;

    public IEnumerable<string> Tags;

    public Dictionary<string, object> AdditionalFields = new Dictionary<string, object>();

  }
}