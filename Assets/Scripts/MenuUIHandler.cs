using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public void StartNew()
    {
        GameManager.Instance.GetPlayerName();
        SceneManager.LoadScene(1);
        GameManager.Instance.InitBestScore();
    }

    public void Exit()
    {
        GameManager.Instance.SaveBestScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
