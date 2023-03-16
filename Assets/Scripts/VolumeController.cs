using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour

{
    public Slider slider;

    public GameObject ArrowRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ArrowRight.activeSelf == true)
        {
            if (Input.GetKey("right"))
            {
                slider.value++;

            }
            else if (Input.GetKey("left"))
            {
                slider.value--;
            }


        }
    }
}
