using Unity.VisualScripting;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    private enum Isotopes
    {
        None,
        Hydrogen,
        Helium,
        Beryllium,
        Boro,
        Carbon
    };
    private Isotopes isotope = Isotopes.None;
    private bool isReacting = false;

    public GameObject dragObject;
    public Hydrogen counterHydrogenGas;
    public Helium helium;
    public Beryllium beryllium;
    public Boro boro;
    public Carbon carbon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isReacting)
        {
            if (IsDraggingHydrogen())
            {
                isotope = Isotopes.Hydrogen;
            }

            if (IsDraggingHelium())
            {
                isotope = Isotopes.Helium;
            }

            if (IsDraggingBeryllium())
            {
                isotope = Isotopes.Beryllium;
            }

            if (IsDraggingBoro())
            {
                isotope = Isotopes.Boro;
            }

            if (IsDraggingCarbon())
            {
                isotope = Isotopes.Carbon;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Disable temporarily the collider to avoid detecting the object itself
            dragObject.GetComponent<Collider2D>().enabled = false;

            CheckHidrogenCollision();
            CheckHeliumCollision();
            CheckBerylliumCollision();
            CheckBoroCollision();
            CheckCarbonCollision();

            // Enable the collider again
            dragObject.GetComponent<Collider2D>().enabled = true;
        }
    }

    public bool IsDraggingHydrogen()
    {
        if (isReacting) return false;

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
                isReacting = true;
                Debug.Log("Hydrogen isotope placed in the reactor");
                // TODO: Add the hydrogen isotope reaction functionality
                counterHydrogenGas.startCounting = true;
                counterHydrogenGas.IncrementCounterHydrogenGas();

                //isotope = Isotopes.None;
                //isReacting = false;
            }
        }
        else
        {
            Debug.Log("The object is not over a reactor");
            isotope = Isotopes.None;
        }
    }

    public bool IsDraggingHelium()
    {
        if (isReacting) return false;

        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Helium"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckHeliumCollision()
    {
        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Reactor"))
        {
            // Debug.Log("The object is over a reactor");
            if (isotope == Isotopes.Helium)
            {
                isReacting = true;
                Debug.Log("Helium isotope placed in the reactor");
                // TODO: Add the helium isotope reaction functionality
                helium.ChangeWaterToHelium();
                helium.startCounting = true;
                helium.DecrementCounterMeltdownByHelium();

                //isotope = Isotopes.None;
                //isReacting = false;
            }
        }
        else
        {
            Debug.Log("The object is not over a reactor");
            isotope = Isotopes.None;
        }
    }

    public bool IsDraggingBeryllium()
    {
        if (isReacting) return false;

        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Beryllium"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckBerylliumCollision()
    {
        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Reactor"))
        {
            // Debug.Log("The object is over a reactor");
            if (isotope == Isotopes.Beryllium)
            {
                isReacting = true;
                Debug.Log("Beryllium isotope placed in the reactor");
                // TODO: Add the helium isotope reaction functionality
                beryllium.startCounting = true;
                beryllium.DecrementCounterOverheatingByBeryllium();

                //isotope = Isotopes.None;
                //isReacting = false;
            }
        }
        else
        {
            Debug.Log("The object is not over a reactor");
            isotope = Isotopes.None;
        }
    }

    public bool IsDraggingBoro()
    {
        if (isReacting) return false;

        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Boro"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckBoroCollision()
    {
        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Reactor"))
        {
            // Debug.Log("The object is over a reactor");
            if (isotope == Isotopes.Boro)
            {
                isReacting = true;
                Debug.Log("Boro isotope placed in the reactor");
                // TODO: Add the helium isotope reaction functionality
                boro.startCounting = true;
                boro.DecrementCounterShutdownByBoro();

                //isotope = Isotopes.None;
                //isReacting = false;
            }
        }
        else
        {
            Debug.Log("The object is not over a reactor");
            isotope = Isotopes.None;
        }
    }

    public bool IsDraggingCarbon()
    {
        if (isReacting) return false;

        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Carbon"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckCarbonCollision()
    {
        Vector2 mousePosition = GetMouseWorldPos();

        // Throw a raycast from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Reactor"))
        {
            // Debug.Log("The object is over a reactor");
            if (isotope == Isotopes.Carbon)
            {
                isReacting = true;
                Debug.Log("Carbon isotope placed in the reactor");
                // TODO: Add the carbon isotope reaction functionality
                carbon.startCountingTritium = true;
                carbon.DecrementCounterDamageByCarbon();

                //isotope = Isotopes.None;
                //isReacting = false;
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
