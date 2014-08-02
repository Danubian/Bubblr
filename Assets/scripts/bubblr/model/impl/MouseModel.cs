using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MouseModel : IMouseModel
{
    private bool _clicking = false;
    public bool clicking
    {
        get
        {
            return this._clicking;
        }
        set
        {
            this._clicking = value;
        }
    }

    public MouseModel()
    {

    }
}
