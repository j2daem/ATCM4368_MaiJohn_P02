using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : GameplayState
{
    [SerializeField] UIManager uIManager;

    public override void Enter()
    {
        Debug.Log("Current State: Win State");
        uIManager.DisplayWinText();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
