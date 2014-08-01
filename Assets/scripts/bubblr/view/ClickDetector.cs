using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ClickDetector : MouseDetector
{
    public Signal clickSignal = new Signal();

    void OnMouseDown()
    {
        Debug.Log("ClickDetector : Mouse Down");
        clickSignal.Dispatch();
    }
}