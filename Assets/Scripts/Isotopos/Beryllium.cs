using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beryllium : MonoBehaviour
{
    private int counterToOverheating = 17; // 17 seconds that represents 17 hours
    private float time = 0f;
    public bool startCounting = false;

    public SpriteRenderer berylliumSprite;
    public GameObject explosion;

    public GameObject primaryCircuit;
    public GameObject secondaryCircuit;
    public GameObject steamCircuit;

    // For graphics
    public GameObject neutronMeter;
    public GameObject termoMeter;

    public ReactorHeating reactorHeating;
    public ShowCanvas showCanvas;

    public void DecrementCounterOverheatingByBeryllium()
    {
        counterToOverheating--;
        Debug.Log("Time for reactor to meltdown: " + counterToOverheating);

        // Enable the sprite renderer
        berylliumSprite.gameObject.SetActive(true);

        reactorHeating.HeatReactor(counterToOverheating);

        if (counterToOverheating == 10)
        {
            neutronMeter.GetComponent<Animator>().SetBool("isNeutronHigh", true);

            // Accelerate the reactor
            primaryCircuit.GetComponent<Animator>().speed = 1.5f;
            secondaryCircuit.GetComponent<Animator>().speed = 1.5f;
            steamCircuit.GetComponent<Animator>().speed = 1.5f;

            berylliumSprite.gameObject.GetComponent<Animator>().speed = 1.5f;
        }

        if (counterToOverheating == 5)
        {
            termoMeter.GetComponent<Animator>().SetBool("isTemperatureHigh", true);

            // Accelerate even more the reactor
            primaryCircuit.GetComponent<Animator>().speed = 2.0f;
            secondaryCircuit.GetComponent<Animator>().speed = 2.0f;
            steamCircuit.GetComponent<Animator>().speed = 2.0f;

            berylliumSprite.gameObject.GetComponent<Animator>().speed = 2.0f;
        }

        if (counterToOverheating == 0)
        {
            Debug.Log("Reactor has had meltdown");
            startCounting = false;
            counterToOverheating = 20;

            explosion.gameObject.SetActive(true);
            explosion.GetComponent<Animator>().SetBool("explode", true);

            showCanvas.ShowIsotopeCanvas("Berylium");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounting)
        {
            // Increment the time counter every second
            time += Time.deltaTime;

            if (time >= 1f)
            {
                DecrementCounterOverheatingByBeryllium();
                time = 0f;
            }
        }
    }
}
