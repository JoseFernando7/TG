using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorHeating : MonoBehaviour
{
    public SpriteRenderer normalReactor;
    public SpriteRenderer normalCtrlBrs;
    public SpriteRenderer normalCbtlBrs;
    public SpriteRenderer hotReactor;
    public SpriteRenderer hotCtrlBrs;
    public SpriteRenderer hotCbtlBrs;

    public void HeatReactor(int counter)
    {
        VanishNormalReactor(counter);

        // Enable the hot reactor sprite renderer
        hotReactor.gameObject.SetActive(true);
        hotCtrlBrs.gameObject.SetActive(true);
        hotCtrlBrs.gameObject.SetActive(true);

        // Calculate the oppacity of the sprite
        float alpha = Mathf.InverseLerp(0, 20, counter);

        Color hotReactorActualColor = hotReactor.color;
        hotReactorActualColor.a = 1 - alpha;
        hotReactor.color = hotReactorActualColor;

        Color hotCtrlBrsActualColor = hotCtrlBrs.color;
        hotCtrlBrsActualColor.a = 1 - alpha;
        hotCtrlBrs.color = hotCtrlBrsActualColor;

        Color hotCbtlBrsActualColor = hotCbtlBrs.color;
        hotCbtlBrsActualColor.a = 1 - alpha;
        hotCbtlBrs.color = hotCbtlBrsActualColor;
    }

    void VanishNormalReactor(int counter)
    {
        // Calculate the oppacity of the sprite
        float alpha = Mathf.InverseLerp(0, 20, counter);

        Color hotReactorActualColor = hotReactor.color;
        hotReactorActualColor.a = alpha;
        hotReactor.color = hotReactorActualColor;

        Color hotCtrlBrsActualColor = hotCtrlBrs.color;
        hotCtrlBrsActualColor.a = alpha;
        hotCtrlBrs.color = hotCtrlBrsActualColor;

        Color hotCbtlBrsActualColor = hotCbtlBrs.color;
        hotCbtlBrsActualColor.a = alpha;
        hotCbtlBrs.color = hotCbtlBrsActualColor;

        if (alpha == 0)
        {
            // Disable the normal reactor sprite renderer
            normalReactor.gameObject.SetActive(false);
            normalCtrlBrs.gameObject.SetActive(false);
            normalCbtlBrs.gameObject.SetActive(false);
        }
    }
}
