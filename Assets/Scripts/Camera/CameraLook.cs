using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    //public Transform playerRef;
    public float mouseSensitivity = 2f;
    float xRotation = 0f;


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
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        xRotation += mouseX;
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        //playerRef.Rotate(Vector3.up * mouseX);
    }
}
