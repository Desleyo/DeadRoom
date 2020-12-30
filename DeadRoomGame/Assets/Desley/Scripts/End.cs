using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject player;
    public void ChangeScene()
    {
        Destroy(player);
        SceneManager.LoadScene(0);
    }
}
