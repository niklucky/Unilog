using System;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
using MiniJSON;
namespace UnilogTransports.Graylog
{
  public static class GELFMessageExtensions
  {
    public static string ToJson(this GELFMessage message)
    {
      var dict = new Dictionary<string, object>();
      dict["short_message"] = message.ShortMessage;
      dict["host"] = message.Host;
      dict["timestamp"] = message.Timestamp;
      dict["level"] = (int)message.Level;

      if (message.AdditionalFields != null)
      {
        foreach (var af in message.AdditionalFields)
        {
          string key = "_" + af.Key;
          dict[key] = af.Value;
        }
      }
      if (message.Tags != null)
      {
        dict["_tags"] = string.Join(",", message.Tags);
      }

      return Json.Serialize(dict);
    }
  }
}
