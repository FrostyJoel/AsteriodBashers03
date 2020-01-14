using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public List<ButtonBase> buttons = new List<ButtonBase>();

    public void ResetButtonTriggers()
    {
        foreach (ButtonBase button in buttons)
        {
            button.triggerd = false;
            if(button.buttonTrigger != null)
            {
                button.buttonTrigger.color = Color.red;
            }
        }
    }
    public void Laser()
    {
        //WeaponSet = Laser
        GameManager.instance.weaponMan.ResetWeapons();
        GameManager.instance.weaponMan.laser = true;
    }
    public void Magnet()
    {
        //WeaponSet = Magnet
        GameManager.instance.weaponMan.ResetWeapons();
        GameManager.instance.weaponMan.magnet = true;
    }
    public void Shield()
    {
        //WeaponSet = Shield
        GameManager.instance.weaponMan.ResetWeapons();
        GameManager.instance.weaponMan.shield = true;
    }
}
