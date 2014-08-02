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

    public Signal dragSignal = new Signal();

    public Signal releaseSignal = new Signal();

    GameObject latestGO;

    public Vector3 lastPosition = Vector3.zero;

    public Vector3 velocity = Vector3.zero;

    internal void init()
    {
        Debug.Log("Initializing BallView");
        //latestGO = Instantiate(Resources.Load("Textfield")) as GameObject;
        //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
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

        Debug.Log(this.gameObject);

        this.gameObject.AddComponent<ClickDetector>();
        ClickDetector clicker = this.gameObject.GetComponent<ClickDetector>() as ClickDetector;
        clicker.clickSignal.AddListener(onClick);

        this.gameObject.AddComponent<DragDetector>();
        DragDetector dragger = this.gameObject.GetComponent<DragDetector>() as DragDetector;
        dragger.dragSignal.AddListener(onDrag);

        this.gameObject.AddComponent<ReleaseDetector>();
        ReleaseDetector releaser = this.gameObject.GetComponent<ReleaseDetector>() as ReleaseDetector;
        releaser.releaseSignal.AddListener(onReleased);
    }

    void Update()
    {

        //transform.Rotate(Vector3.up * Time.deltaTime * theta, Space.Self);
        //transform.position += velocity;
    }

    void onClick()
    {
        Debug.Log("BallView : onClick");
        clickSignal.Dispatch();
    }

    void onDrag()
    {
        Debug.Log("BallView : onDrag");
        dragSignal.Dispatch();
    }

    void onReleased()
    {
        Debug.Log("BallView : onReleased");
        releaseSignal.Dispatch();
    }
}
