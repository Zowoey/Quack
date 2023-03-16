using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSelect : MonoBehaviour
{
    float Selection;
    [Space(10)]
    [Header("Start")]
    public GameObject StartSprite;
    public GameObject StartSelected;
    [Space(10)]
    [Header("Settings")]
    public GameObject SettingsSprite;
    public GameObject SettingsSelected;
    [Space(10)]
    [Header("Quit")]
    public GameObject QuitSprite;
    public GameObject QuitSelected;
    public GameObject Background;
    public int gameStartScene;
    //------------------------------------------------------Select Menu------------------------------------------------------

    public GameObject Volume;
    public GameObject Back;
    public GameObject BackSelected;
    public bool SettingsMenu = false;
    public GameObject VolumeArrowRight;
    public GameObject VolumeArrowLeft;

    //-----------------------------------------------------------------------------------------------------------------------
    // public void StartGame()
    // {
    //     SceneManager.LoadScene(0);
    // }

    public void QuitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        Selection = 1;
        Background.SetActive(true);
    }


    void Update()
    {
        // if (Input.GetKey(KeyCode.Escape))
        // {

        // }
        // if (MenuScreen.activeSelf == true && Input.GetKey(KeyCode.Escape))
        // {

        // }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Selection <= 3)
            {
                Selection++;
            }
            if (Selection > 3)
            {
                Selection = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Selection >= 1)
            {
                Selection--;
            }
            if (Selection < 1)
            {
                Selection = 3;
            }
        }
        if (Selection == 1 && Volume.activeSelf == false)
        {
            StartSprite.SetActive(false);
            StartSelected.SetActive(true);
            SettingsSprite.SetActive(true);
            SettingsSelected.SetActive(false);
            QuitSprite.SetActive(true);
            QuitSelected.SetActive(false);

        }
        if (Selection == 2 && Volume.activeSelf == false)
        {
            StartSprite.SetActive(true);
            StartSelected.SetActive(false);
            SettingsSprite.SetActive(false);
            SettingsSelected.SetActive(true);
            QuitSprite.SetActive(true);
            QuitSelected.SetActive(false);
            //------------------------------------------------------Select Menu------------------------------------------------------
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.SettingsMenu = true;
                Volume.SetActive(true);
                Back.SetActive(true);
                BackSelected.SetActive(false);
                StartSprite.SetActive(false);
                StartSelected.SetActive(false);
                SettingsSprite.SetActive(false);
                SettingsSelected.SetActive(false);
                QuitSprite.SetActive(false);
                QuitSelected.SetActive(false);
                VolumeArrowLeft.SetActive(true);
                VolumeArrowRight.SetActive(true);


            }
        }
        if (this.SettingsMenu == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                Back.SetActive(false);
                BackSelected.SetActive(true);
                VolumeArrowLeft.SetActive(false);
                VolumeArrowRight.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                VolumeArrowLeft.SetActive(true);
                VolumeArrowRight.SetActive(true);
                Back.SetActive(true);
                BackSelected.SetActive(false);
            }
        }
        if (BackSelected.activeSelf == true && Input.GetKey(KeyCode.Space))
        {
            this.SettingsMenu = false;
            Volume.SetActive(false);
            Back.SetActive(false);
            BackSelected.SetActive(false);
            StartSprite.SetActive(true);
            StartSelected.SetActive(false);
            SettingsSprite.SetActive(false);
            SettingsSelected.SetActive(true);
            QuitSprite.SetActive(true);
            QuitSelected.SetActive(false);
        }


        //-----------------------------------------------------------------------------------------------------------------------
        if (Selection == 3 && Volume.activeSelf == false)
        {
            StartSprite.SetActive(true);
            StartSelected.SetActive(false);
            SettingsSprite.SetActive(true);
            SettingsSelected.SetActive(false);
            QuitSprite.SetActive(false);
            QuitSelected.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                QuitGame();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------


    }
}
