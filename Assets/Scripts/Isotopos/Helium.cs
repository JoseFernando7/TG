using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using TMPro;

public class Helium : MonoBehaviour
{
    // Para el canvas
    public GameObject canvas;
    public Image fondo;
    public TextMeshProUGUI texto;
    public float fadingTime = 1f;
    // ------------------------------------

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

            ShowCanvas();
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
