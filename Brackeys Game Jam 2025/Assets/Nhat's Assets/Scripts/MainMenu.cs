using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string MainMenu_Scene = "MainMenu";
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

    
}
