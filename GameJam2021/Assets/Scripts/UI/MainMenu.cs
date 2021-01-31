using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public string firstSceneName = "TestScene";

    public void NewGame()
    {
        SceneManager.LoadScene(firstSceneName);
    }
}
