using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Unilog.Debug("Test2");
    }
}
