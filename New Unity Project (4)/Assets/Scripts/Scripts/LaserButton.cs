using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButton : ButtonBase
{
    public override void Selected()
    {
        base.Selected();
        GameManager.instance.buttonMan.Laser();
    }
}
