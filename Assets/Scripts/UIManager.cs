using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelectionMenu;
    public GameObject optionMenu;
    public GameObject creditMenu;
    public GameObject pauseMenu;
    public GameObject audioMenu;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject creditButton;
    public GameObject menuBG;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            WinCtl();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoseCtl();
        }
    }

    public void OptionMenuCtl()
    {
        audioMenu.SetActive(true);
        startButton.SetActive(false);
        creditMenu.SetActive(false);
        optionMenu.SetActive(false);
        menuBG.SetActive(false);
        creditButton.SetActive(false);
        exitButton.SetActive(false);
    }

    public void BackToMain()
    {
        levelSelectionMenu.SetActive(false);
        creditMenu.SetActive(false);
        pauseMenu.SetActive(false);
        audioMenu.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        mainMenu.SetActive(true);
        startButton.SetActive(true);
        optionMenu.SetActive(true);
        creditButton.SetActive(true);
        exitButton.SetActive(true);
        menuBG.SetActive(true);
    }

    public void LevelSelectionMenu()
    {
        mainMenu.SetActive(false);
        menuBG.SetActive(false);
        levelSelectionMenu.SetActive(true);
    }

    //public void LevelSelection()
    //{
    //    mainMenu.SetActive(false);
    //    levelSelectionMenu.SetActive(true);
    //}

    public void CreditMenuCtl()
    {
        exitButton.SetActive(false);
        startButton.SetActive(false);
        optionMenu.SetActive(false);
        audioMenu.SetActive(false);
        menuBG.SetActive(false);
        creditButton.SetActive(false);
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void WinCtl()
    {
        winScreen.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void LoseCtl()
    {
        loseScreen.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OptionMenuCtlSide()
    {
        audioMenu.SetActive(true);
        //optionMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void PauseMenuBack()
    {
        pauseMenu.SetActive(true);
        audioMenu.SetActive(false);
        //optionMenu.SetActive(false);
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    


    public void ExitGame()
    {
        Application.Quit();
    }

}
