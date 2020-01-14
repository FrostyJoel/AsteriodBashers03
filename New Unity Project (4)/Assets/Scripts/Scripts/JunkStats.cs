using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkStats : MonoBehaviour
{
    [Header("Damage/Fuel")]
    public int damage;
    public int maxDamOrFuel, minDamOrFuel;

    private void Awake()
    {
        damage = Random.Range(Mathf.RoundToInt(GetComponent<SpaceJunk>().scaleMin) + minDamOrFuel, Mathf.RoundToInt(GetComponent<SpaceJunk>().scaleMax) + maxDamOrFuel);
    }
}
