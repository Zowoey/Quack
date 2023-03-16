using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public AudioSource menuClick;
    public GameObject menu;


    void Start()
    {






    }

    // Update is called once per frame
    void Update()
    {
        if (menu.activeSelf)
        {


            if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.UpArrow))
            {
                menuClick.Play();
            }
        }
    }


}
