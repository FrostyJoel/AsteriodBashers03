using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRot : MonoBehaviour
{
    public Transform endPoint;
    public Vector3 startingPos;
    public Vector3 startingRot;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.localPosition;
        startingRot = transform.localEulerAngles;
    }
}
