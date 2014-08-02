using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class CreateBallCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    public override void Execute()
    {
        Debug.Log("Executing CreateBallCommand");

        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("NewCircle"));
        go.name = "Circle";
        go.AddComponent<BallView>();
        go.transform.parent = contextView.transform;

        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;

        go.transform.position = pos;

        //GameObject go2 = new GameObject();
        //go2.name = "WorldView";
        //go2.AddComponent<WorldView>();
        //go2.transform.parent = contextView.transform;
    }
}
