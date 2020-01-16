using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Trash")
        {
            GameManager.instance.soundMan.Play("ShieldHit");
            Destroy(c.gameObject);
        }
    }
}
