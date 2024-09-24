using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab3Transitions : MonoBehaviour
{
    public string colliderID;

    public Image firstImage; // Assign the first image in inspector
    public Image secondImage; // Assign the second image in inspector
    public Image thirdImage; // Assign the second image in inspector

    // Start is called before the first frame update
    void Start()
    {
        // Third image enabled on start and others don't
        firstImage.gameObject.SetActive(false);
        secondImage.gameObject.SetActive(false);
        thirdImage.gameObject.SetActive(true);
    }

    void OnMouseDown()
    {
        if (colliderID == "tab1")
        {
            // Aquí puedes agregar la acción que deseas ejecutar
            firstImage.gameObject.SetActive(true);
            secondImage.gameObject.SetActive(false);
            thirdImage.gameObject.SetActive(false);
        }
        else if (colliderID == "tab2")
        {
            // Aquí puedes agregar la acción que deseas ejecutar
            firstImage.gameObject.SetActive(false);
            secondImage.gameObject.SetActive(true);
            thirdImage.gameObject.SetActive(false);
        }
    }
}
