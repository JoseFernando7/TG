using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hydrogen : MonoBehaviour
{
    private int counterHydrogenGas = 10; // 10 seconds
    private float time = 0f;
    public bool startCounting = false;

    public SpriteRenderer hydrogenGasSprite;
    public GameObject explosion;

    public ShowCanvas showCanvas;

    public void IncrementCounterHydrogenGas()
    {
        counterHydrogenGas--;
        Debug.Log("Time for hydrogen gas to explode: " + counterHydrogenGas);

        // Enable the sprite renderer
        hydrogenGasSprite.gameObject.SetActive(true);

        // Calculate the oppacity of the sprite
        float alpha = Mathf.InverseLerp(0, 20, counterHydrogenGas);
        Color actualColor = hydrogenGasSprite.color;
        actualColor.a = 1 - alpha;
        hydrogenGasSprite.color = actualColor;

        if (counterHydrogenGas == 0)
        {
            Debug.Log("Hydrogen gas exploded");
            startCounting = false;
            counterHydrogenGas = 10;

            explosion.gameObject.SetActive(true);
            explosion.GetComponent<Animator>().SetBool("explode", true);

            showCanvas.ShowIsotopeCanvas("El reactor ha explotado");
        }
    }

    private void Update()
    {
        if (startCounting)
        {
            // Increment the time counter every second
            time += Time.deltaTime;

            if (time >= 1f)
            {
                IncrementCounterHydrogenGas();
                time = 0f;
            }
        }
    }
}
