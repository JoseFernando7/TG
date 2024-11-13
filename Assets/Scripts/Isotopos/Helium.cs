using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using TMPro;
using Unity.VisualScripting;

public class Helium : MonoBehaviour
{
    private int counterMeltdownByHelium = 15; // 10 seconds
    private float time = 0f;
    public bool startCounting = false;

    public SpriteRenderer normalWater;
    public SpriteRenderer heliumGas;
    public GameObject explosion;

    public GameObject secondaryCircuit;
    public GameObject steamCircuit;

    // For graphics
    public GameObject neutronMeter;
    public GameObject termoMeter;

    public ReactorHeating reactorHeating;
    public ShowCanvas showCanvas;

    public void DecrementCounterMeltdownByHelium()
    {
        counterMeltdownByHelium--;
        Debug.Log("Time for reactor to meltdown: " + counterMeltdownByHelium);

        reactorHeating.HeatReactor(counterMeltdownByHelium);

        if (counterMeltdownByHelium == 10)
        {
            neutronMeter.GetComponent<Animator>().SetBool("isNeutronHigh", true);
        }

        if (counterMeltdownByHelium == 5)
        {
            termoMeter.GetComponent<Animator>().SetBool("isTemperatureHigh", true);
            termoMeter.GetComponent<Animator>().SetBool("isTemperatureLow", false);

            // Accelerate the reactor
            heliumGas.gameObject.GetComponent<Animator>().speed = 2.0f;
            secondaryCircuit.GetComponent<Animator>().speed = 2.0f;
            steamCircuit.GetComponent<Animator>().speed = 2.0f;
        }

        if (counterMeltdownByHelium == 0)
        {
            Debug.Log("Reactor has had meltdown");
            startCounting = false;
            counterMeltdownByHelium = 15;

            explosion.gameObject.SetActive(true);
            explosion.GetComponent<Animator>().SetBool("explode", true);

            showCanvas.ShowIsotopeCanvas("Helium");
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
                DecrementCounterMeltdownByHelium();
                time = 0f;
            }
        }
    }

    public void ChangeWaterToHelium()
    {
        normalWater.gameObject.SetActive(false);
        heliumGas.gameObject.SetActive(true);
    }
}
