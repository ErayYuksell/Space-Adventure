using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    int gold;
    int highGold;
    bool collectScore= true;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI gameOverscoreText;
    public TextMeshProUGUI gameOvergoldText;
    void Start()
    {
        goldText.text = "X " + gold;
    }


    void Update()
    {
        // Debug.Log((int)Camera.main.transform.position.y); //bu sekilde int yapmaya cast deniyor 
        if (collectScore)
        {
            score = (int)Camera.main.transform.position.y; //cameranin y degeri arttikca skorumuz artiyor 
            scoreText.text = "Score : " + score;
        }

    }
    public void GainGold()
    {
        FindObjectOfType<SoundControl>().AltinSes();
        gold++;
        goldText.text = "X " + gold;
    }
    public void GameOver()
    {
        if (Options.EasyGetValue() == 1) //Score scene sayfasinda en yuksek degerleri kaydetmek icin yazdik
        {
            highScore = Options.EasyGetValue();  //YENIDEN OLUSTUR
            highGold = Options.EasyGoldGetValue();
            if (score > highScore)
            {
                Options.EasySetValue(score);
            }
            if (gold > highGold)
            {
                Options.EasyGoldSetValue(gold);
            }
        }
        if (Options.MediumGetValue() == 1)
        {
            highScore = Options.MediumGetValue();
            highGold = Options.MediumGoldGetValue();
            if (score > highScore)
            {
                Options.MediumSetValue(score);
            }
            if (gold > highGold)
            {
                Options.MediumGoldSetValue(gold);
            }
        }
        if (Options.HardGetValue() == 1)
        {
            highScore = Options.HardGetValue();
            highGold = Options.HardGoldGetValue();
            if (score > highScore)
            {
                Options.HardSetValue(score);
            }
            if (gold > highGold)
            {
                Options.HardGoldSetValue(gold);
            }
        }
        collectScore = false;
        gameOverscoreText.text = "Score : " + score;
        gameOvergoldText.text = " X " + gold;
    }
}
