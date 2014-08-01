using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class DragDetector : MouseDetector
{
    public Signal dragSignal = new Signal();

    void OnMouseDrag()
    {
        Debug.Log("DragDetector : Mouse dragged");
        dragSignal.Dispatch();
    }
}
