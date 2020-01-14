using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldButton : ButtonBase
{
    public override void Selected()
    {
        base.Selected();
        GameManager.instance.buttonMan.Shield();
    }
}
