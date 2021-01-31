using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public string firstSceneName = "TestScene";

    [SerializeField]
    public string instructionScene = "Instructions";

    public void LoadScene()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    public void InstructionScene()
    {
        SceneManager.LoadScene(instructionScene);
    }
}
