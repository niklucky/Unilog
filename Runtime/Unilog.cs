using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

public enum LogColors
{
  lime,
  orange,
  yellow,
  red,
  white,
  lightblue,
}

public enum LogLevel
{
  Debug = 1,
  Info,
  Log,
  Warning,
  Error,
  Fatal,
}

public static class Unilog
{
  private static bool _isMuted;
  private static bool _isShowClassInfo;
  private static HashSet<LogLevel> _mutedLevels = new HashSet<LogLevel>();
  private static HashSet<string> _mutedTags = new HashSet<string>();
  private static Dictionary<string, UnilogTransports.ITransport> _transports = new Dictionary<string, UnilogTransports.ITransport>();

  private static Dictionary<string, object> _keyValues = new Dictionary<string, object>();

  public static void KeyValueGlobal(string key, object value)
  {
    _keyValues.Add(key, value);
  }
  public static UnilogWorker KeyValue(string key, object value)
  {
    return new UnilogWorker().KeyValue(key, value);
  }
  public static void AddTransport(string name, UnilogTransports.ITransport transport)
  {
    _transports.Add(name, transport);
  }

  public static UnilogWorker Tag(string tag)
  {
    return new UnilogWorker().Tag(tag);
  }
  public static void Debug(params object[] data)
  {
    var level = LogLevel.Debug;
    Unilog.Output(level, data);
  }
  public static void Info(params object[] data)
  {
    var level = LogLevel.Info;
    Unilog.Output(level, data);
  }
  public static void Log(params object[] data)
  {
    var level = LogLevel.Log;
    Unilog.Output(level, data);
  }
  public static void Warning(params object[] data)
  {
    var level = LogLevel.Warning;
    Unilog.Output(level, data);
  }
  public static void Error(params object[] data)
  {
    var level = LogLevel.Error;
    Unilog.Output(level, data);
  }
  public static UnilogWorker Mute()
  {
    return new UnilogWorker();
  }
  public static UnilogWorker Mute(LogLevel level)
  {
    // Disabling total mute settings
    _isMuted = false;
    _mutedLevels.Add(level);
    return new UnilogWorker();
  }
  public static UnilogWorker Mute(string tag)
  {
    _isMuted = false;
    if (tag != "")
      _mutedTags.Add(tag);

    return new UnilogWorker();
  }
  public static UnilogWorker Unmute()
  {
    _isMuted = false;
    return new UnilogWorker();
  }
  public static UnilogWorker Unmute(LogLevel level)
  {
    _isMuted = false;
    _mutedLevels.Remove(level);

    return new UnilogWorker();
  }
  public static UnilogWorker Unmute(string tag)
  {
    _isMuted = false;
    _mutedTags.Remove(tag);
    return new UnilogWorker();
  }
  private static void Output(LogLevel level, params object[] data)
  {
    Output(level, null, null, data);
  }

  public static void Output(LogLevel level, string tag, Dictionary<string, object> kv, params object[] data)
  {
    if (IsMuted(level, tag))
    {
      return;
    }

    var arr = new List<string>();
    foreach (var item in data)
    {
      arr.Add(item.ToString());
    }
    string str = string.Join(",", arr);
    string color = GetColor(level);
    string message = "";

#if UNITY_EDITOR
    string classInfo = "";
    if (_isShowClassInfo)
    {
      StackFrame frame = new StackFrame(1);
      // string methodName = frame.GetMethod().Name;
      // string className = frame.GetMethod().DeclaringType.Name;
      MethodBase method = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
      classInfo = $"<color=magenta>({method.ReflectedType.FullName}.{method})</color>";
    }
    if (tag != null)
    {
      tag = $"<color={color.ToString()}>[{tag}]</color> ";
    }

    message = $"{tag}{classInfo}{str}";
#else
    message = $"[{tag}] {str}";
  
#endif

    // Sending to Graylog2 if setup
    if (_transports.Count > 0)
    {
      foreach (var transport in _transports)
      {
        if (_keyValues != null)
        {
          foreach (var item in _keyValues)
          {
            kv.Add(item.Key, item.Value);
          }
        }
        transport.Value.Send(level, message, _keyValues);
      }
    }
    // Logging to console by Unity
    if (level == LogLevel.Warning)
    {
      UnityEngine.Debug.LogWarning(message);
      return;
    }
    if (level == LogLevel.Error || level == LogLevel.Fatal)
    {
      UnityEngine.Debug.LogError(message);
      return;
    }
    UnityEngine.Debug.Log(message);
    _keyValues.Clear();
  }

  private static bool IsMuted(LogLevel level)
  {
    if (_isMuted)
      return true;

    return _mutedLevels.Contains(level);
  }
  private static bool IsMuted(LogLevel level, string tag)
  {
    if (IsMuted(level))
      return true;

    if (tag != "")
      return _mutedTags.Contains(tag);

    return false;
  }

  private static string GetColor(LogLevel level)
  {
    if (level == LogLevel.Warning)
    {
      return LogColors.orange.ToString();
    }
    if (level == LogLevel.Log)
    {
      return LogColors.white.ToString();
    }
    if (level == LogLevel.Info)
    {
      return LogColors.lightblue.ToString();
    }
    if (level == LogLevel.Error || level == LogLevel.Fatal)
    {
      return LogColors.red.ToString();
    }
    // Debug
    return LogColors.lime.ToString();
  }
}
