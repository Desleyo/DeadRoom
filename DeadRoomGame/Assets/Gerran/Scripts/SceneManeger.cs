using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
        print("quited");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Gerran");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenuTest");
    }
}
