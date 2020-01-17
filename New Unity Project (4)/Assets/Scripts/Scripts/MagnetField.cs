using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Fuel")
        {
            GameManager.instance.soundMan.Play("FuelPickup");
            GameManager.instance.ship.currentFuel += collision.transform.GetComponent<AstroidMovement>().totalAmountOfDamOrFuel;
            GameManager.instance.ship.UiUpdate();
            Destroy(collision.gameObject);
        }
    }
}
