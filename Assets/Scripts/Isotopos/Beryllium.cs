using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beryllium : MonoBehaviour
{
    private int counterToOverheating = 10; // 10 seconds
    private float time = 0f;
    public bool startCounting = false;

    public SpriteRenderer berylliumSprite;
    public GameObject explosion;

    public ReactorHeating reactorHeating;
    public ShowCanvas showCanvas;

    public void DecrementCounterOverheatingByBeryllium()
    {
        counterToOverheating--;
        Debug.Log("Time for reactor to meltdown: " + counterToOverheating);

        // Enable the sprite renderer
        berylliumSprite.gameObject.SetActive(true);

        reactorHeating.HeatReactor(counterToOverheating);

        if (counterToOverheating == 0)
        {
            Debug.Log("Reactor has had meltdown");
            startCounting = false;
            counterToOverheating = 10;

            explosion.gameObject.SetActive(true);
            explosion.GetComponent<Animator>().SetBool("explode", true);

            showCanvas.ShowIsotopeCanvas();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounting)
        {
            // Increment the time counter every second
            time += Time.deltaTime;

            if (time >= 1f)
            {
                DecrementCounterOverheatingByBeryllium();
                time = 0f;
            }
        }
    }
}
