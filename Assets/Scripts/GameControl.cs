using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject jumpButton;
    public GameObject board;
    public GameObject menuButton;
    public GameObject slider;
    void Start()
    {
        gameOverPanel.SetActive(false);
        UIOpen();
    }
    public void GameOver()
    {
        FindObjectOfType<SoundControl>().OyunBittiSes();
        gameOverPanel.SetActive(true);
        FindObjectOfType<Score>().GameOver(); //findObejctOfType() kesinlikle bak
        FindObjectOfType<PlayerMovement>().GameOver();
        FindObjectOfType<CameraMovement>().GameOver(); // camera movementi gormuyor wtf
        UIClose();
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    void UIOpen()
    {
        joystick.SetActive(true);
        jumpButton.SetActive(true);
        board.SetActive(true);
        menuButton.SetActive(true);
        slider.SetActive(true);
    }
    void UIClose()
    {
        joystick.SetActive(false);
        jumpButton.SetActive(false);
        board.SetActive(false);
        menuButton.SetActive(false);
        slider.SetActive(false);
    }
}
