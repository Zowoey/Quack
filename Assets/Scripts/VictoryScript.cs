using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour

{
    public GameObject VictoryScreen;
    public AudioSource Victory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] DuckArray = GameObject.FindGameObjectsWithTag("Duck");
        if (DuckArray.Length == 0)
        {
            Debug.Log("bark");
        }
        // if (GameObject.FindGameObjectWithTag("Duck"))
        // {
        //     Debug.Log("victory");
        //     VictoryScreen.SetActive(true);
        //     Victory.Play();
        // }
    }
}
