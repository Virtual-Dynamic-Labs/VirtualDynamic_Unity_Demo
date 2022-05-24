using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("LoginScene");
        SceneManager.LoadScene("LoginScene");
    }

    public void MainMenuScene()
    {
        Debug.Log("MainMenuScene");
        SceneManager.LoadScene("MainMenuScene");
    }

    public void SettingScene()
    {
        Debug.Log("SettingScene");
        SceneManager.LoadScene("SettingScene");
    }
}