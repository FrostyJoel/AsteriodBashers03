using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagnetButton : ButtonBase
{
    public override void Selected()
    {
        base.Selected();
        GameManager.instance.buttonMan.Magnet();
    }
}
