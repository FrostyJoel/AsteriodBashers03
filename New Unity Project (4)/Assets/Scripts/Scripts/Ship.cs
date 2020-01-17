using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Camera Shake")]
    public float dur;
    public float magnitude;
    [Header("Fuel")]
    public float currentFuel;
    public float dangerzone = 250.0f;
    public float maxFuel;
    public float speed;
    public SoundMan sound;

    [Header("UX")]
    public Light topLeft;
    public Light topRight;
    public Light sideLeft;
    public Light sideRight;

    public Color colWhite;
    public Color colRed;

    public float lowIntensity = 4.5f;
    public float highIntensity = 25f;

    public Material normalStateMaterial;
    public Material DangerStateMaterial;

    public GameObject Lamps;

    private bool hasStopped;

    private void Start()
    {
        sound = GameManager.instance.soundMan;
        GameManager.instance.uiMan.maxFuel = maxFuel;
        UiUpdate();
    }
    public IEnumerator FuelUsage()
    {
        while(true)
        {
            if(currentFuel > 0)
            {
                Damage(speed);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                AstroidMovement[] allStuf = FindObjectsOfType<AstroidMovement>();
                foreach (AstroidMovement junk in allStuf)
                {
                    Destroy(junk.gameObject);
                }
                GameManager.instance.uiMan.GameOver();
                yield break;
            }
        }
    }

    public void Damage(float damage)
    {
        currentFuel -= damage;
        UiUpdate();
    }

    public void Update()
    {
        if (currentFuel > dangerzone)
        {
            topLeft.color = colWhite;
            topRight.color = colWhite;
            sideLeft.color = colWhite;
            sideRight.color = colWhite;

            topLeft.intensity = lowIntensity;
            topRight.intensity = lowIntensity;
            sideLeft.intensity = lowIntensity;
            sideRight.intensity = lowIntensity;

            Lamps.GetComponent<MeshRenderer>().materials[0] = normalStateMaterial;
            Lamps.GetComponent<MeshRenderer>().materials[2] = normalStateMaterial;
        }

        if (currentFuel <= dangerzone)
        {
            Sound s = System.Array.Find(GameManager.instance.soundMan.sounds, sound => sound.name == "Alarm");
            if (s.source.isPlaying)
            {
                return;
            }
            GameManager.instance.soundMan.Play("Alarm");
            topLeft.color = colRed;
            topRight.color = colRed;
            sideLeft.color = colRed;
            sideRight.color = colRed;

            topLeft.intensity = highIntensity;
            topRight.intensity = highIntensity;
            sideLeft.intensity = highIntensity;
            sideRight.intensity = highIntensity;

            Lamps.GetComponent<MeshRenderer>().materials[0] = DangerStateMaterial;
            Lamps.GetComponent<MeshRenderer>().materials[2] = DangerStateMaterial;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.GetComponent<AstroidMovement>() != null)
        {
            Damage(collision.transform.GetComponent<AstroidMovement>().totalAmountOfDamOrFuel);
            Destroy(collision.gameObject);
        }
    }

    public void UiUpdate()
    {
        GameManager.instance.uiMan.fuelLeft = currentFuel;
    }
}
