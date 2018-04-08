using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject Pause;
    public GameObject Panell;
    public GameObject GO;

	public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        Panell.SetActive(true);
        WinScreen.SetActive(true);
        WinScreen.GetComponent<Animator>().SetTrigger("Show");
        Time.timeScale = 0;
        
    }

    public void Lose()
    {
        Panell.SetActive(true);
        LoseScreen.SetActive(true);
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
}
