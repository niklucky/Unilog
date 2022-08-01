using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnilogSetup : MonoBehaviour
{
  [SerializeField] UnilogTransports.Graylog.Options _graylogOptions;
  [SerializeField] List<LogLevel> _muteLevels;
  [SerializeField] List<string> _muteTags;

  // Start is called before the first frame update
  void Awake()
  {
    if (_graylogOptions != null)
    {
      Debug.Log("Setting graylog");
      Unilog.AddTransport("graylog", new UnilogTransports.GrayLog(_graylogOptions));
    }
    Unilog.KeyValue("key1", 1).KeyValue("key2", "222").Tag("tag1").Error("CYBERPUCK: new test error message");
    foreach (var tag in _muteTags)
    {
      Unilog.Mute(tag);
    }
    foreach (var level in _muteLevels)
    {
      Unilog.Mute(level);
    }
  }
}
