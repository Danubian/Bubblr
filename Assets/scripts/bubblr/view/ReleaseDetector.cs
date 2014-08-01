using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ReleaseDetector : MouseDetector
{
    public Signal releaseSignal = new Signal();

    void OnMouseUp()
    {
        Debug.Log("Drag ended!");
        releaseSignal.Dispatch();
    }
}
