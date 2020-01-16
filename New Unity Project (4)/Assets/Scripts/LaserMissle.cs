using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMissle : MonoBehaviour
{
    public float maxTime;
    public float currentTime;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
        Timer();
    }
    public void Timer()
    {
        currentTime += Time.deltaTime;
        if(currentTime > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
