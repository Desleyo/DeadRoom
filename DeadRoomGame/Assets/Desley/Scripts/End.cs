using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject player;
    public float timer = Mathf.Infinity, seconds;

    public void SetTimer()
    {
        timer = seconds;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            ChangeScene();
            timer = Mathf.Infinity;
        }
    }

    public void ChangeScene()
    {
        Destroy(player);
        SceneManager.LoadScene(0);
    }
}
