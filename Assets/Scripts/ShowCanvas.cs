using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using TMPro;

public class ShowCanvas : MonoBehaviour
{
    // Para el canvas
    public GameObject canvas;
    public Image fondo;
    public TextMeshProUGUI texto;
    public float fadingTime = 1f;
    // ------------------------------------

    public void ShowIsotopeCanvas()
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
