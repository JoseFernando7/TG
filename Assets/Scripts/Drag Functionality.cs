using UnityEngine;
using UnityEngine.EventSystems;

public class DragFunctionality : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private bool isOverReactor = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Empieza a arrastrar
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mientras arrastras, sigue la posici�n del mouse
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Al soltar, si no est� sobre el reactor, vuelve a la posici�n original
        if (!isOverReactor)
        {
            transform.position = originalPosition;
        }
    }

    // Llamado cuando entra en el "Reactor"
    public void SetOverReactor(bool isOver)
    {
        isOverReactor = isOver;
    }
}
