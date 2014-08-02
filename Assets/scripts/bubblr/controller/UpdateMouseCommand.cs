using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class UpdateMouseCommand : Command
{
    [Inject]
    public bool clicking { get; set; }

    [Inject]
    public IMouseModel model{ get; set; }

    public override void Execute()
    {
        model.clicking = clicking;
    }
}
