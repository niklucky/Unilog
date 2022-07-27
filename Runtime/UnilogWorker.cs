using System.Collections.Generic;

// Experimental logging library.
// Will replace current if will be more usable
public class UnilogWorker
{
  private string _tag;
  private Dictionary<string, object> _keyValues = new Dictionary<string, object>();

  public UnilogWorker Tag(string tag)
  {
    _tag = tag;
    return this;
  }

  public UnilogWorker KeyValue(string key, object value)
  {
    _keyValues.Add(key, value);
    return this;
  }

  public UnilogWorker Mute()
  {
    Unilog.Mute();
    return this;
  }
  public UnilogWorker Mute(LogLevel level)
  {
    Unilog.Mute(level);
    return this;
  }
  public UnilogWorker Mute(string tag)
  {
    Unilog.Mute(tag);
    return this;
  }
  public UnilogWorker Unmute()
  {
    Unilog.Unmute();
    return this;
  }
  public UnilogWorker Unmute(LogLevel level)
  {
    Unilog.Unmute(level);
    return this;
  }
  public UnilogWorker Unmute(string tag)
  {
    Unilog.Unmute(tag);
    return this;
  }
  public void Debug(params object[] data)
  {
    Unilog.Output(LogLevel.Debug, _tag, _keyValues, data);
  }
  public void Log(params object[] data)
  {
    Unilog.Output(LogLevel.Log, _tag, _keyValues, data);
  }
  public void Info(params object[] data)
  {
    Unilog.Output(LogLevel.Info, _tag, _keyValues, data);
  }
  public void Warning(params object[] data)
  {
    Unilog.Output(LogLevel.Warning, _tag, _keyValues, data);
  }
  public void Error(params object[] data)
  {
    Unilog.Output(LogLevel.Error, _tag, _keyValues, data);
  }

}