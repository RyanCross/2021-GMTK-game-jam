using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeshiftTimerController : MonoBehaviour
{
    public Slider shapeshiftTimerSlider;
    public float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        shapeshiftTimerSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        shapeshiftTimerSlider.value += curTime + Time.deltaTime;
        if (shapeshiftTimerSlider.value == shapeshiftTimerSlider.maxValue)
        {
            shapeshiftTimerSlider.value = 0;
            GameEvents.shapeshiftTimerElapsed();
        }

    }
}
