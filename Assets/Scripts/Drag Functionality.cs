using UnityEngine;
using UnityEngine.EventSystems;

public class DragFunctionality : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;

    private void Start()
    {
        // Save the original position of the object
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        // Check when the user clicks on the object
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        // Check when the user releases the object
        isDragging = false;

        // Disable temporarily the collider to avoid detecting the object itself
        GetComponent<Collider2D>().enabled = false;

        // Return the object to its original position
        transform.position = originalPosition;

        // Enable the collider again
        GetComponent<Collider2D>().enabled = true;
    }

    private void Update()
    {
        // Check if the object is being dragged and update its position
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
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
