using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hydrogen : MonoBehaviour
{
    // Para el canvas
    public GameObject canvas;
    public Image fondo;
    public TextMeshProUGUI texto;
    public float fadingTime = 1f;
    // ------------------------------------

    private int counterHydrogenGas = 10; // 10 seconds
    private float time = 0f;
    public bool startCounting = false;

    public SpriteRenderer hydrogenGasSprite;
    public GameObject explosion;

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

            ShowCanvas();
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

    public void ShowCanvas()
    {
        // Habilitar el Canvas
        canvas.SetActive(true);
        fondo.raycastTarget = true; // Asegura que el panel bloquee interacciones

        // Iniciar la corutina de desvanecimiento
        StartCoroutine(Fading());
    }

    private IEnumerator Fading()
    {
        float tiempo = 0f;
        Color textoColor = texto.color;
        Color fondoColor = fondo.color;

        // Fading para mostrar
        while (tiempo < fadingTime)
        {
            tiempo += Time.deltaTime;
            textoColor.a = Mathf.Lerp(0, 1, tiempo / fadingTime);
            fondoColor.a = Mathf.Lerp(0, 1, tiempo / fadingTime);
            texto.color = textoColor;
            fondo.color = fondoColor;
            yield return null;
        }
    }
}
