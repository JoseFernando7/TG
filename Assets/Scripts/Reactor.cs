using Unity.VisualScripting;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    private enum Isotopes
    {
        None,
        Hydrogen,
    };
    private Isotopes isotope = Isotopes.None;

    public GameObject dragObject;
    public Hydrogen counterHydrogenGas;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsDraggingHydrogen())
            {
                isotope = Isotopes.Hydrogen;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Disable temporarily the collider to avoid detecting the object itself
            dragObject.GetComponent<Collider2D>().enabled = false;

            CheckHidrogenCollision();

            // Enable the collider again
            dragObject.GetComponent<Collider2D>().enabled = true;
        }
    }

    public bool IsDraggingHydrogen()
    {
        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Hydrogen"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckHidrogenCollision()
    {
        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Reactor"))
        {
            // Debug.Log("The object is over a reactor");
            if (isotope == Isotopes.Hydrogen)
            {
                Debug.Log("Hydrogen isotope placed in the reactor");
                // TODO: Add the hydrogen isotope reaction functionality
                counterHydrogenGas.startCounting = true;
                counterHydrogenGas.IncrementCounterHydrogenGas();

                isotope = Isotopes.None;
            }
        }
        else
        {
            Debug.Log("The object is not over a reactor");
            isotope = Isotopes.None;
        }
    }

    // Get the mouse position in the 2D world
    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        // Keep the z coordinate of the mouse position
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
