/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

//Not extending EventMediator anymore
public class BallMediator : Mediator
{
    [Inject]
    public BallView view { get; set; }

    public override void OnRegister()
    {

        //Listen to the view for a Signal
        view.clickSignal.AddListener(onViewClicked);

        view.dragSignal.AddListener(onViewDragged);

        view.init();
    }

    public override void OnRemove()
    {
        view.clickSignal.RemoveListener(onViewClicked);

        view.dragSignal.RemoveListener(onViewDragged);

        Debug.Log("Mediator OnRemove");
    }

    private void onViewClicked()
    {
        Debug.Log("BallMediator : View click detected");
        //Vector3 pos = Input.mousePosition;
        //pos = Camera.main.ScreenToWorldPoint(pos);
        //pos.z = 0;
        //view.transform.position = pos;
        //Dispatch a Signal. We're adding a string value (different from MyFirstContext,
        //just to show how we can Inject values into commands)
    }

    private void onViewDragged()
    {
        Debug.Log("BallMediator : View click detected");
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
        view.transform.position = pos;
        //Dispatch a Signal. We're adding a string value (different from MyFirstContext,
        //just to show how we can Inject values into commands)
    }
}

