using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePlanetRotation : MonoBehaviour
{
    [Header ("Rotation")]
    public float yRot;
    public float xRot;
    public float zRot;
    public float rotSpeed;
    public Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        rot.y = yRot;
        rot.x = xRot;
        rot.z = zRot;
        transform.Rotate(rot * rotSpeed * Time.deltaTime);
    }
}
