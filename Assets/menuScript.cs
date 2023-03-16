using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public AudioSource menuClick;
    public GameObject menu;

    public GameObject varGameObject = GameObject.Find("Hand");
    public GameObject varGameObjectTwo = GameObject.Find("Main Camera");
    public GameObject varGameObjectThree = GameObject.Find("Canvas");


    void Start()
    {






    }

    // Update is called once per frame
    void Update()
    {
        if (menu.activeSelf)
        {



            varGameObject.GetComponent<BreadBullet>().enabled = false;
            varGameObjectTwo.GetComponent<CameraMovement>().enabled = false;
            varGameObjectTwo.GetComponent<CameraLook>().enabled = false;
            varGameObjectTwo.GetComponent<FootStepScript>().enabled = false;
            varGameObjectThree.GetComponent<BreadDisplay>().enabled = false;


            if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.UpArrow))
            {
                menuClick.Play();
            }
        }
    }


}
