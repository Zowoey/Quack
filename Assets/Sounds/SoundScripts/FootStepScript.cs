using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript : MonoBehaviour
{
    public AudioSource footstep;

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
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D))
        {
            if (!footstep.isPlaying)
            {
                footstep.Play();
            }
        }
        else
        {
            footstep.Stop();
        }

    }
}



