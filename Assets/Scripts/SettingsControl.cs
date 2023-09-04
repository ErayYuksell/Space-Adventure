using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;
    private void Start()
    {
        if (Options.EasyGetValue()== 1) //daha onceden secilmis olan seviyeyi ayarliyor scene yuklendiginde
        {
            easyButton.interactable = false; 
            mediumButton.interactable = true;
            hardButton.interactable = true;
        }
        if (Options.MediumGetValue() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = false;
            hardButton.interactable = true;
        }
        if (Options.HardGetValue() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = true;
            hardButton.interactable = false;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Choise(string level) //radio button tasarimi 
        //bir button secildiginde o buttona bir daha basilamiyor, digerlerine basilabiliyor 
    {
        switch (level)
        {
            case "easy":
                Options.EasySetValue(1); //1 acik 0 kapali anlaminda 
                Options.MediumSetValue(0);
                Options.HardSetValue(0);
                easyButton.interactable = false; //etkilesimini acip kapatiyorum 
                mediumButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "medium":
                Options.EasySetValue(0);
                Options.MediumSetValue(1);
                Options.HardSetValue(0);
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                Options.EasySetValue(0);
                Options.MediumSetValue(0);
                Options.HardSetValue(1);
                easyButton.interactable = true;
                mediumButton.interactable = true;
                hardButton.interactable = false;
                break;
        }
    }
}
