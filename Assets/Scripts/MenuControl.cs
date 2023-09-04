using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Sprite[] muzikIcons = default;
    public Button muzikButton = default;

    void Start()
    {
        if (Options.IsThereHaveRecord() == false) //herhangi bir kayit yoksa kolaydan baslatiyor oyunu
        {
            Options.EasySetValue(1);
        }
        if (Options.MuzikHaveRecord() == false) //harhangi bir kayit yoksa muzik acik basliyor 
        {
            Options.MuzikOpenSetValue(1);
        }
        checkMusicSettings();
    }


    void Update()
    {

    }
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void HighScore()
    {
        SceneManager.LoadScene("Score");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Muzik() // tiklandiginda sprite muzik kapali hale gelir tekrar tiklandiginda muzik acik sprite haline gecer 
    {
        if (Options.MuzikOpenGetValue() == 1)
        {
            Options.MuzikOpenSetValue(0);
            MuzikControl.instance.PlayMuzik(false);
            muzikButton.image.sprite = muzikIcons[0];
        }
        else
        {
            Options.MuzikOpenSetValue(1);
            MuzikControl.instance.PlayMuzik(true);
            muzikButton.image.sprite = muzikIcons[1];
        }
    }
    public void checkMusicSettings()
    {
        if (Options.MuzikOpenGetValue() == 1)
        {
            muzikButton.image.sprite = muzikIcons[1];
            MuzikControl.instance.PlayMuzik(true);

        }
        else
        {
            muzikButton.image.sprite = muzikIcons[0];
            MuzikControl.instance.PlayMuzik(false);

        }
    }
}
