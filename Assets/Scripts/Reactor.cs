using UnityEngine;
using UnityEngine.EventSystems;

public class Reactor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public DragFunctionality dragImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Detecta cuando la imagen está sobre el "reactor"
        dragImage.SetOverReactor(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Detecta cuando la imagen sale del "reactor"
        dragImage.SetOverReactor(false);
    }
}
