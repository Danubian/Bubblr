using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ClickDetector : EventView
{
    public Signal clickSignal = new Signal();

    void OnMouseDown()
    {
        clickSignal.Dispatch();
    }
}