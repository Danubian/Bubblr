﻿using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class CollisionDetector : EventView
{
    public Signal<Collision2D> collisionSignal = new Signal<Collision2D>();

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("CollisionDetector : OnCollisionEnter2D");
        //GameObject go = (GameObject) GameObject.Instantiate(Resources.Load("Audio"));
        //AudioSource sound = gameObject.GetComponent<AudioSource>();
        //sound.Play();

        collisionSignal.Dispatch(coll);
    }
}   
