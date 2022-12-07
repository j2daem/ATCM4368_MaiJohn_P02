using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : GameplayState
{
    [SerializeField] UIManager uIManager;

    public override void Enter()
    {
        Debug.Log("Current State: Lose State");
        uIManager.DisplayLoseText();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
