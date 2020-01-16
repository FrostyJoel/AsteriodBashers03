using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    public MagnetParticle magnetpull;
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Fuel")
        {
            GameManager.instance.ship.currentFuel += collision.transform.GetComponent<AstroidMovement>().totalAmountOfDamOrFuel;
            GameManager.instance.ship.UiUpdate();
            Destroy(collision.gameObject);
        }
    }
}
