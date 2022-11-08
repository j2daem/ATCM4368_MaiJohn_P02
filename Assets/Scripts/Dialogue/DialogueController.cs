using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] DialogueManager _dialogueManager;
    [SerializeField] DialogueData[] _dialogueArray;
    private int _dialogueIndex;
    private DialogueData _activeDialogueData;
    private bool _dialogueInitialized;


    private void Awake()
    {
        _dialogueIndex = 0;
        _activeDialogueData = _dialogueArray[_dialogueIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
