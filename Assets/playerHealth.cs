using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    private Slider slider;
    //private float sliderValue;
    private int seedHealth = 50;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 50;
    }

   public void changeSliderValue()
    {
        if (slider.value < 100)
        {
            slider.value += seedHealth; 
        }
    }
}
