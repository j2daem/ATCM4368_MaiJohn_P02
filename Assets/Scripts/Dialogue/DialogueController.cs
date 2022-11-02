using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] DialogueManager _dialogueManager;
    [SerializeField] DialogueData _heroData;
    [SerializeField] DialogueData _bossData;

    private DialogueData _activeDialogueData;


    private void Start()
    {
        _activeDialogueData = _heroData;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _activeDialogueData = _heroData;
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            _activeDialogueData = _bossData;
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_dialogueManager.DialogueStarted)
            {
                _dialogueManager.StartDialogue(_activeDialogueData);
            }

            else
            {
                _dialogueManager.DisplayNextSentence();
            }
            
        }
    }
}
