using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BallVO
{
    private Vector3 _pos = Vector3.zero;
    public Vector3 pos 
    { 
        get
        {
            return this._pos;
        }
        set
        {
            this._pos = value;
        }
    }
    private Vector3 _velocity = Vector3.zero;
    public Vector3 veloity 
    {
        get
        {
            return this._velocity;
        }
        set
        {
            this._velocity = value;
        }
    }
}
