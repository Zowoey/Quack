using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BreadDisplay : MonoBehaviour

{

    public AudioSource toastershot;

    public int breadCount;
    public bool isFiring;
    public Text breadDisplay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("MenuTag"))
        {
            return;
        }

        breadDisplay.text = breadCount.ToString();
        if (Input.GetMouseButtonDown(0) && !isFiring && breadCount > 0)
        {
            GameObject.Find("Hand").GetComponent<Animator>().SetTrigger("Shoot");

            isFiring = true;
            breadCount--;

            if (isFiring == true)
            {
                toastershot.Play();
            }
            isFiring = false;


        }

    }
}
