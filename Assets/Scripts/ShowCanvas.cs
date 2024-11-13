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
                strings[1] = "En reactores de agua ligera, el hidrógeno presente en las moléculas de agua actúa como moderador" +
                            " disminuyendo la velocidad de los neutrones para que sean captados eficientemente por el combustible nuclear." + 
                            " Sin embargo, si se acumula gas hidrógeno en el sistema, este podría mezclarse con oxígeno, formando una mezcla explosiva." +
                            " Esto ocurre porque el hidrógeno es extremadamente inflamable y, bajo ciertas condiciones, puede detonar en presencia de oxígeno" +
                            " y una fuente de ignición, poniendo en riesgo la seguridad del reactor.";
                return strings;

            case "Helium":
                strings[0] = "El reactor se ha derretido";
                strings[1] = "Reemplazar el agua por helio como moderador no es efectivo, ya que el helio no modera neutrones" +
                            " de manera significativa debido a su baja capacidad de interacción con ellos. Al no moderar adecuadamente los neutrones," +
                            " el combustible puede experimentar fisión descontrolada, generando un aumento en la temperatura del núcleo." +
                            " Esto puede llevar al sobrecalentamiento y, en casos extremos, al derretimiento del núcleo";
                return strings;

            case "Berylium":
                strings[0] = "El reactor se ha sobrecalentado";
                strings[1] = "El berilio es un material moderador que se utiliza en reactores de agua pesada para ralentizar los neutrones." +
                            " Sin embargo, si se sobrecalienta, el berilio puede perder sus propiedades moderadoras y hacer que los neutrones" +
                            " reboten en este material generando así una aceleración de la reacción de fisión." +
                            " Esto puede provocar un aumento en la temperatura del núcleo y, en casos extremos, el sobrecalentamiento del reactor.";
                return strings;

            case "Boro":
                strings[0] = "El reactor se ha apagado por baja intensidad";
                strings[1] = "Con una alta sección transversal para la captura de neutrones, el boro-10 es ideal para su uso en barras de control." +
                            " Cuando se introduce al núcleo, el boro-10 absorbe neutrones de manera eficiente, lo cual disminuye la cantidad de neutrones" +
                            " disponibles para mantener la reacción en cadena de fisión. Esto permite regular o detener la reacción, evitando" +
                            " que el reactor alcance un estado de sobrecalentamiento o inestabilidad. Este procedimiento es usado frecuentemente" +
                            " como protocolo para apagar un reactor nuclear de forma segura.";
                return strings;

            case "Carbon":
                strings[0] = "El reactor se ha dañado por el óxido";
                strings[1] = "La exposición prolongada de Carbono-14 puede inducir la formación de tritio (3H), un isótopo radiactivo del hidrógeno." +
                            " La presencia de tritio aumenta la radioactividad del reactor y, de no controlarse, puede llevar a la oxidación" +
                            " y degradación de los componentes de carbono así como los demás materiales que componen el reactor.";
                return strings;

            default:
                strings[0] = "Isótopo";
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

        // Mostrar el mensaje y el título
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
