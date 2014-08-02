using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class WorldView : View
{
    public Signal mouseDownSignal = new Signal();

    internal void init()
    {
        Debug.Log("Initializing WorldView");

        //this.gameObject.AddComponent<CollisionDetector>();
        //CollisionDetector collisionDetector = this.gameObject.GetComponent<CollisionDetector>() as CollisionDetector;
        //collisionDetector.collisionSignal.AddListener(onCollision);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click.");
            mouseDownSignal.Dispatch();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right click.");
            mouseDownSignal.Dispatch();
        }

        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Pressed middle click.");
            mouseDownSignal.Dispatch();
        }

    }

    void onCollision()
    {
        Debug.Log("WorldView : onCollision");
    }

}
