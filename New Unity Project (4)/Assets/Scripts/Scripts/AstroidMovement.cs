using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    [Header("MoveSpeed")]
    public float moveSpeed;
    public float minMovespeed;
    public float maxMovespeed;

    [Header("Damage/Fuel")]
    public float totalAmountOfDamOrFuel;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if(child.GetComponent<JunkStats>() != null)
            {
                int dam = child.GetComponent<JunkStats>().damage;
                totalAmountOfDamOrFuel += dam;
            }
        }
        moveSpeed = Random.Range(minMovespeed, maxMovespeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardRot = transform.rotation * transform.forward;
        transform.Translate(forwardRot *moveSpeed* Time.deltaTime);
    }
}
