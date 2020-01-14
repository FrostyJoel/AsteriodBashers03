using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJunk : MonoBehaviour
{
    [HideInInspector]
    public float randomScale;

    public float randomRMin, randomRMax = 360;
    public float randomRX, randomRY, randomRZ;
    public float randomSX, randomSY, randomSZ;

    [Header("Scale")]
    public float scaleMin;
    public float scaleMax;

    [Header("RotationSpeed")]
    public float maxRotationSpeed;
    public float rotSpeed;

    [Header("Parent")]
    public GameObject parent;

    private void Awake()
    {
        if (scaleMin <= 0 || scaleMax <= 0)
            Debug.LogError("Scale can't be zero");
    }
    public void SetRotation()
    {
        randomRX = Random.Range(randomRMin, randomRMax);
        randomRY = Random.Range(randomRMin, randomRMax);
        randomRZ = Random.Range(randomRMin, randomRMax);
        rotSpeed = Random.Range(0f, maxRotationSpeed);
    }
    public void SetScale()
    {
        randomScale = Random.Range(scaleMin, scaleMax);
        randomSX = randomScale;
        randomSY = randomScale;
        randomSZ = randomScale;
        transform.localScale = new Vector3(randomSX, randomSY, randomSZ);
    }
    // Update is called once per frame
    public virtual void Update()
    {
        transform.Rotate(new Vector3(randomRX, randomRY, randomRZ) * rotSpeed * Time.deltaTime);
    }
}
