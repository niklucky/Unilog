using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnilogSetup : MonoBehaviour
{
    [SerializeField] UnilogTransports.GrayLog2 _loggerTransport;
    [SerializeField] bool _isMuted;

    // Start is called before the first frame update
    void Awake()
    {
        // var graylog = new UnilogTransports.GrayLog2(_loggerTransport)
        // Unilog.AddTransport(_loggerTransport);
    }
}
