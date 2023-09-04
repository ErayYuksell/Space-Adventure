using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{
    public TextMeshProUGUI easyScore, easyGold, mediumScore, mediumGold, hardScore, hardGold;
    private void Start()
    {
        easyScore.text = "Score: " + Options.EasyGetValue();
        easyGold.text = " X " + Options.EasyGoldGetValue();

        mediumScore.text = "Score: " + Options.MediumGetValue();
        mediumGold.text = " X " + Options.MediumGoldGetValue();

        hardScore.text = "Score: " + Options.HardGetValue();
        hardGold.text = " X " + Options.HardGoldGetValue();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
