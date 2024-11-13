using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// TODO: Separar la lógica de los contadores en diferentes funciones

public class Carbon : MonoBehaviour
{
    private int counterToTritium = 10; // 10 seconds
    private int counterToOxide = 7; // 10 seconds
    private int counterToReactorToGetDamaged = 10; // 10 seconds
    private float time = 0f;

    public bool startCountingTritium = false;
    public bool startCountingToOxide = false;
    public bool startCountingToDamage = false;

    public SpriteRenderer carbonSprite;
    public SpriteRenderer tritioSprite;
    public SpriteRenderer oxideSprite;

    // For graphics
    public GameObject neutronMeter;

    public GameObject explosion;
    public ShowCanvas showCanvas;

    public void DecrementCounterDamageByCarbon()
    {
        carbonSprite.gameObject.SetActive(true);

        if (counterToTritium > 0)
        {
            counterToTritium--;
            Debug.Log("Time for reactor to be radioactive by tritium: " + counterToTritium);
        }

        if (counterToTritium == 0)
        {
            //startCountingTritium = false;
            startCountingToOxide = true;
            counterToTritium = 10;
        }

        if (startCountingToOxide)
        {
            counterToOxide--;
            Debug.Log("Time for reactor to oxide: " + counterToOxide);

            // Enable the sprite renderer
            tritioSprite.gameObject.SetActive(true);

            float alpha = Mathf.InverseLerp(0, 20, counterToOxide);

            Color tritiumActualColor = tritioSprite.color;
            tritiumActualColor.a = 1 - alpha;
            tritioSprite.color = tritiumActualColor;

            if (counterToOxide == 0)
            {
                oxideSprite.gameObject.SetActive(true);
                startCountingToDamage = true;
                startCountingToOxide = false;

                neutronMeter.GetComponent<Animator>().SetBool("isNeutronHigh", true);
            }
        }

        if (startCountingToDamage)
        {
            counterToReactorToGetDamaged--;
            Debug.Log("Time for reactor to get damaged by oxide: " + counterToReactorToGetDamaged);
        }
        
        if (counterToReactorToGetDamaged == 0)
        {
            Debug.Log("Reactor has been damaged");
            startCountingToDamage = false;
            counterToReactorToGetDamaged = 10;

            explosion.gameObject.SetActive(true);
            explosion.GetComponent<Animator>().SetBool("explode", true);

            startCountingTritium = false;

            showCanvas.ShowIsotopeCanvas("Carbon");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountingTritium)
        {
            // Increment the time counter every second
            time += Time.deltaTime;

            if (time >= 1f)
            {
                DecrementCounterDamageByCarbon();
                time = 0f;
            }
        }
    }
}
