using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManeger : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        print("quited");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadDevScene()
    {
        SceneManager.LoadScene("Devmode");
    }

    public void MenuScene()
    {
        GameObject.FindGameObjectWithTag("eventPlayer").GetComponent<End>().ChangeScene();
    }
}
