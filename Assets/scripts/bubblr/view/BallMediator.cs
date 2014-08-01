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

        view.init();
    }

    public override void OnRemove()
    {
        view.clickSignal.RemoveListener(onViewClicked);
        Debug.Log("Mediator OnRemove");
    }

    private void onViewClicked()
    {
        Debug.Log("View click detected");
        //Dispatch a Signal. We're adding a string value (different from MyFirstContext,
        //just to show how we can Inject values into commands)
    }
}

