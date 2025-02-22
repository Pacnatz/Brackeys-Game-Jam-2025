using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string MainMenu_Scene = "MainMenu";
    string Gameplay1_Scene = "Gameplay1";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public  void Mainmenu()
    {
        Debug.Log("Load MainMenu");
        SceneManager.LoadScene(MainMenu_Scene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Gameplay01()
    {
        Debug.Log("Load gameplay");
        SceneManager.LoadScene(Gameplay1_Scene);
    }
}
