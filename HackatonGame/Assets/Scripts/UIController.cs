using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject Pause;
    public GameObject Panell;
    public GameObject GO;
    float timer;
    public Text test;
    public Text testLose;


    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        Panell.SetActive(true);
        WinScreen.SetActive(true);
        WinScreen.GetComponent<Animator>().SetBool("NBool", true);
        Time.timeScale = 0;
        
    }

    public void AddScore()
    {
        timer += 25;
    }

    public void Lose()
    {
        Panell.SetActive(true);
        LoseScreen.SetActive(true);
        testLose.text = Mathf.Round(timer).ToString();
        LoseScreen.GetComponent<Animator>().SetBool("NBool",true);
        Time.timeScale = 0;
    }

    public void ShowPause()
    {
        GO.GetComponent<SpeedRinoParent>().speed = 0;
        Pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void STopPause()
    {
        GO.GetComponent<SpeedRinoParent>().speed = 0.04f;
        Pause.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        test.text = "" + Mathf.Round(timer).ToString();
    }
}
