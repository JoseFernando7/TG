using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boro : MonoBehaviour
{
    private int counterToShutdown = 20; // 10 seconds
    private float time = 0f;
    public bool startCounting = false;

    public SpriteRenderer boroSprite;
    public SpriteRenderer normalControlBars;

    public GameObject primaryCircuit;
    public GameObject secondaryCircuit;
    public GameObject steamCircuit;

    // For graphics
    public GameObject neutronMeter;
    public GameObject termoMeter;

    public ShowCanvas showCanvas;

    public void DecrementCounterShutdownByBoro()
    {
        counterToShutdown--;
        Debug.Log("Time for reactor to shutdown: " + counterToShutdown);

        // Enable the sprite renderer
        normalControlBars.gameObject.SetActive(false);
        boroSprite.gameObject.SetActive(true);

        if (counterToShutdown == 18)
        {
            boroSprite.gameObject.GetComponent<Animator>().SetBool("boro-bars", true);
        }

        if (counterToShutdown == 10)
        {
            neutronMeter.GetComponent<Animator>().SetBool("isNeutronLow", true);

            // Slow down the reactor
            primaryCircuit.GetComponent<Animator>().speed = 0.5f;
            secondaryCircuit.GetComponent<Animator>().speed = 0.5f;
            steamCircuit.GetComponent<Animator>().speed = 0.5f;
        }

        if (counterToShutdown == 5)
        {
            termoMeter.GetComponent<Animator>().SetBool("isTemperatureLow", true);

            // Slow down even more the reactor
            primaryCircuit.GetComponent<Animator>().speed = 0.2f;
            secondaryCircuit.GetComponent<Animator>().speed = 0.2f;
            steamCircuit.GetComponent<Animator>().speed = 0.2f;
        }

        if (counterToShutdown == 0)
        {
            Debug.Log("Reactor has been shutdown");
            startCounting = false;
            counterToShutdown = 10;

            // Stop all the animations
            primaryCircuit.GetComponent<Animator>().SetBool("isReactorShuttedDown", true);
            secondaryCircuit.GetComponent<Animator>().SetBool("isReactorShuttedDown", true);
            steamCircuit.GetComponent<Animator>().SetBool("isReactorShuttedDown", true);

            showCanvas.ShowIsotopeCanvas("Boro");
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
                DecrementCounterShutdownByBoro();
                time = 0f;
            }
        }
    }
}
