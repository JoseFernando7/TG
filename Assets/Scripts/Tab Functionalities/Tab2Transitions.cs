using UnityEngine;

public class Tab2Transitions : MonoBehaviour
{
    public string colliderID;

    public SpriteRenderer firstRender; // Assign the first render in inspector
    public SpriteRenderer secondRender; // Assign the second render in inspector
    public SpriteRenderer thirdRender; // Assign the second render in inspector

    // Start is called before the first frame update
    void Start()
    {
        // Second image enabled on start and others don't
        firstRender.gameObject.SetActive(false);
        secondRender.gameObject.SetActive(true);
        thirdRender.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (colliderID == "tab1")
        {
            // Aqu� puedes agregar la acci�n que deseas ejecutar
            firstRender.gameObject.SetActive(true);
            secondRender.gameObject.SetActive(false);
            thirdRender.gameObject.SetActive(false);
        }
        else if (colliderID == "tab3")
        {
            // Aqu� puedes agregar la acci�n que deseas ejecutar
            firstRender.gameObject.SetActive(false);
            secondRender.gameObject.SetActive(false);
            thirdRender.gameObject.SetActive(true);
        }
    }
}
