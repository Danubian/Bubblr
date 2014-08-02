using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class WorldMediator : Mediator
{
    [Inject]
    public WorldView view { get; set; }

    [Inject]
    public IMouseModel mouseModel { get; set; }

    [Inject]
    public RequestBallCreationSignal createBall { get; set; }

    public override void OnRegister()
    {
        Debug.Log("WorldMediator : OnRegister");
        //Listen to the view for a Signal
        view.mouseDownSignal.AddListener(onMouseDown);

        view.init();
    }

    public override void OnRemove()
    {
        Debug.Log("WorldMediator : OnRemove");
    }

    public void onMouseDown()
    {
        Debug.Log("WorldMediator : onMouseDown");
        if (!mouseModel.clicking)
        {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = 0;
            createBall.Dispatch(pos, Vector2.zero);
        }
            
    }
}
