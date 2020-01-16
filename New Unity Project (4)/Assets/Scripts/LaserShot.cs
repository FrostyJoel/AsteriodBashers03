using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public Vector3 position;
    public GameObject rightLaser;
    public GameObject LeftLaser;

    public Transform barrelTransform;
    public float moveSpeed; 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
