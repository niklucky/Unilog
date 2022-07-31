using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestEnum
{
  Example,
  Error
}

public class UnilogSetup : MonoBehaviour
{
  [SerializeField] UnilogTransports.GrayLog _graylog;
  [SerializeField] bool _isMuted;
  [SerializeField] LogLevel _muteLevels;
  [SerializeField] List<string> _muteTags;

  // Start is called before the first frame update
  void Awake()
  {
    if (_isMuted)
    {
      Unilog.Mute();
    }
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
