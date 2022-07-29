using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestEnum {
    Example,
    Error
}

public class UnilogSetup : MonoBehaviour
{
    [SerializeField] UnilogTransports.GrayLog2 _graylog;
    [SerializeField] bool _isMuted;
    [SerializeField] LogLevel _muteLevels;
    [SerializeField] List<string> _muteTags;

    // Start is called before the first frame update
    void Awake()
    {
        // var graylog = new UnilogTransports.GrayLog2(_loggerTransport)
        // Unilog.AddTransport(_loggerTransport);
        Unilog.Mute("test");
        Unilog.Tag("test").Warning("warning1");
        Unilog.Warning("warning 2");
        Unilog.Unmute("test");
        Unilog.Tag("test").Warning("warning3");

        Unilog.Tag("tag1").Tag("tag2").Tag(TestEnum.Example).Log("3 tags");

        Unilog.Mute("test");
        Unilog.Tag("test").Tag("tag2").Tag(TestEnum.Example).Log("Muted log");
    }
}
