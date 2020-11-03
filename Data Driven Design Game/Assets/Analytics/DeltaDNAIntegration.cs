using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeltaDNA;

public class DeltaDNAIntegration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    // Configure the SDK
	    DDNA.Instance.SetLoggingLevel(DeltaDNA.Logger.Level.DEBUG);
	    DDNA.Instance.ClientVersion = "1.0.0";
        
	    // Start collecting data
	    DDNA.Instance.StartSDK();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
