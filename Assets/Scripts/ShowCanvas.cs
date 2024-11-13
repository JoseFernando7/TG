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
    public Image background;
    public TextMeshProUGUI title;
    public TextMeshProUGUI text;
    public float fadingTime = 1f;
    // ------------------------------------

    public string[] ShowIsotopeTitleAndText(string isotope)
    {
        string[] strings = new string[2];

        switch (isotope)
        {
            case "Hydrogen":
                strings[0] = "El reactor ha explotado";
                strings[1] = "En reactores de agua ligera, el hidr�geno presente en las mol�culas de agua act�a como moderador" +
                            " disminuyendo la velocidad de los neutrones para que sean captados eficientemente por el combustible nuclear." + 
                            " Sin embargo, si se acumula gas hidr�geno en el sistema, este podr�a mezclarse con ox�geno, formando una mezcla explosiva." +
                            " Esto ocurre porque el hidr�geno es extremadamente inflamable y, bajo ciertas condiciones, puede detonar en presencia de ox�geno" +
                            " y una fuente de ignici�n, poniendo en riesgo la seguridad del reactor.";
                return strings;

            case "Helium":
                strings[0] = "El reactor se ha derretido";
                strings[1] = "Reemplazar el agua por helio como moderador no es efectivo, ya que el helio no modera neutrones" +
                            " de manera significativa debido a su baja capacidad de interacci�n con ellos. Al no moderar adecuadamente los neutrones," +
                            " el combustible puede experimentar fisi�n descontrolada, generando un aumento en la temperatura del n�cleo." +
                            " Esto puede llevar al sobrecalentamiento y, en casos extremos, al derretimiento del n�cleo";
                return strings;

            case "Berylium":
                strings[0] = "El reactor se ha sobrecalentado";
                strings[1] = "El berilio es un material moderador que se utiliza en reactores de agua pesada para ralentizar los neutrones." +
                            " Sin embargo, si se sobrecalienta, el berilio puede perder sus propiedades moderadoras y hacer que los neutrones" +
                            " reboten en este material generando as� una aceleraci�n de la reacci�n de fisi�n." +
                            " Esto puede provocar un aumento en la temperatura del n�cleo y, en casos extremos, el sobrecalentamiento del reactor.";
                return strings;

            case "Boro":
                strings[0] = "El reactor se ha apagado por baja intensidad";
                strings[1] = "Con una alta secci�n transversal para la captura de neutrones, el boro-10 es ideal para su uso en barras de control." +
                            " Cuando se introduce al n�cleo, el boro-10 absorbe neutrones de manera eficiente, lo cual disminuye la cantidad de neutrones" +
                            " disponibles para mantener la reacci�n en cadena de fisi�n. Esto permite regular o detener la reacci�n, evitando" +
                            " que el reactor alcance un estado de sobrecalentamiento o inestabilidad. Este procedimiento es usado frecuentemente" +
                            " como protocolo para apagar un reactor nuclear de forma segura.";
                return strings;

            case "Carbon":
                strings[0] = "El reactor se ha da�ado por el �xido";
                strings[1] = "La exposici�n prolongada de Carbono-14 puede inducir la formaci�n de tritio (3H), un is�topo radiactivo del hidr�geno." +
                            " La presencia de tritio aumenta la radioactividad del reactor y, de no controlarse, puede llevar a la oxidaci�n" +
                            " y degradaci�n de los componentes de carbono as� como los dem�s materiales que componen el reactor.";
                return strings;

            default:
                strings[0] = "Is�topo";
                strings[1] = "Mensaje";
                return strings;
        }
    }

    public void ShowIsotopeCanvas(string isotope)
    {
        // Get the title and text for the isotope
        string[] strings = ShowIsotopeTitleAndText(isotope);

        // Habilitar el Canvas
        canvas.SetActive(true);
        background.raycastTarget = true; // Asegura que el panel bloquee interacciones

        // Mostrar el mensaje y el t�tulo
        title.text = strings[0];
        text.text = strings[1];

        // Iniciar la corutina de desvanecimiento
        StartCoroutine(Fading());
    }

    private IEnumerator Fading()
    {
        float tiempo = 0f;
        Color textoColor = text.color;
        Color fondoColor = background.color;

        // Fading para mostrar
        while (tiempo < fadingTime)
        {
            tiempo += Time.deltaTime;
            textoColor.a = Mathf.Lerp(0, 1, tiempo / fadingTime);
            fondoColor.a = Mathf.Lerp(0, 1, tiempo / fadingTime);
            text.color = textoColor;
            background.color = fondoColor;
            yield return null;
        }
    }
}
