using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public LayerMask stuffLayer;
    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.GetComponent<AstroidMovement>() != null)
        {
            GameManager.instance.soundMan.Play("ShieldHit");
            Destroy(c.gameObject);
        }
    }
}
