using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using TMPro;
using Unity.VisualScripting;

public class Helium : MonoBehaviour
{
    private int counterMeltdownByHelium = 10; // 10 seconds
    private float time = 0f;
    public bool startCounting = false;

    public SpriteRenderer normalWater;
    public SpriteRenderer heliumGas;
    public SpriteRenderer normalReactor;
    public SpriteRenderer normalCtrlBrs;
    public SpriteRenderer normalCbtlBrs;
    public SpriteRenderer hotReactor;
    public SpriteRenderer hotCtrlBrs;
    public SpriteRenderer hotCbtlBrs;
    public GameObject explosion;

    public ShowCanvas showCanvas;

    public void DecrementCounterMeltdownByHelium()
    {
        counterMeltdownByHelium--;
        Debug.Log("Time for reactor to meltdown: " + counterMeltdownByHelium);

        // Disable the normal reactor sprite renderer
        normalReactor.gameObject.SetActive(false);
        normalCtrlBrs.gameObject.SetActive(false);
        normalCbtlBrs.gameObject.SetActive(false);

        // Enable the hot reactor sprite renderer
        hotReactor.gameObject.SetActive(true);
        hotCtrlBrs.gameObject.SetActive(true);
        hotCtrlBrs.gameObject.SetActive(true);

        // Calculate the oppacity of the sprite
        float alpha = Mathf.InverseLerp(0, 20, counterMeltdownByHelium);

        Color hotReactorActualColor = hotReactor.color;
        hotReactorActualColor.a = 1 - alpha;
        hotReactor.color = hotReactorActualColor;

        Color hotCtrlBrsActualColor = hotCtrlBrs.color;
        hotCtrlBrsActualColor.a = 1 - alpha;
        hotCtrlBrs.color = hotCtrlBrsActualColor;

        Color hotCbtlBrsActualColor = hotCbtlBrs.color;
        hotCbtlBrsActualColor.a = 1 - alpha;
        hotCbtlBrs.color = hotCbtlBrsActualColor;

        if (counterMeltdownByHelium == 0)
        {
            Debug.Log("Reactor has had meltdown");
            startCounting = false;
            counterMeltdownByHelium = 10;

            explosion.gameObject.SetActive(true);
            explosion.GetComponent<Animator>().SetBool("explode", true);

            showCanvas.ShowIsotopeCanvas("El reactor se ha derretido");
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
