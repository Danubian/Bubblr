using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BallView : View
{
    public Signal clickSignal = new Signal();

    GameObject latestGO;

    internal void init()
    {
        //latestGO = Instantiate(Resources.Load("Textfield")) as GameObject;
        //GameObject go = latestGO;
        //go.name = "first";

        //TextMesh textMesh = go.GetComponent<TextMesh>();
        //textMesh.text = "http://www.thirdmotion.com";
        //textMesh.font.material.color = Color.red;

        //Vector3 localPosition = go.transform.localPosition;
        //localPosition.x -= go.renderer.bounds.extents.x;
        //localPosition.y += go.renderer.bounds.extents.y;
        //go.transform.localPosition = localPosition;

        //Vector3 extents = Vector3.zero;
        //extents.x = go.renderer.bounds.size.x;
        //extents.y = go.renderer.bounds.size.y;
        //extents.z = go.renderer.bounds.size.z;
        //(go.collider as BoxCollider).size = extents;
        //(go.collider as BoxCollider).center = -localPosition;

        //go.transform.parent = gameObject.transform;

        //go.AddComponent<ClickDetector>();
        //ClickDetector clicker = go.GetComponent<ClickDetector>() as ClickDetector;
        //clicker.clickSignal.AddListener(onClick);
    }

    void Update()
    {
        //transform.Rotate(Vector3.up * Time.deltaTime * theta, Space.Self);
    }

    void onClick()
    {
        clickSignal.Dispatch();
    }
}
