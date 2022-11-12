using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    [SerializeField] DialogueManager _dialogueManager;
    [SerializeField] private DialogueData[] _dialogueArray = null;

    private DialogueData _activeDialogueData;
    private int _dialogueIndex;
    private bool _endCutscene;

    private void Start()
    {
        _dialogueIndex = 0;
        _endCutscene = false;

        // Assign active dialogue and pass to manager if valid
        if (_dialogueArray[_dialogueIndex] != null)
        {
            _activeDialogueData = _dialogueArray[_dialogueIndex];
            _dialogueManager.StartDialogue(_activeDialogueData);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (!_endCutscene))
        {
            if (!_dialogueManager.DialogueStarted)
            {
                // Load in the next DialogueData object in DialogueArray
                IndexDialogue();
            }

            else
            {
                _dialogueManager.DisplayNextSentence();
            }
        }

        else if (Input.GetKeyDown(KeyCode.Return) && (_endCutscene))
        {
            // Reconsider loading a specific scene by name / string
            int currentActiveSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentActiveSceneIndex + 1);
        }
    }

    private void IndexDialogue()
    {
        _dialogueIndex++;

        if (_dialogueIndex < _dialogueArray.Length)
        {
            _activeDialogueData = _dialogueArray[_dialogueIndex];
            _dialogueManager.StartDialogue(_activeDialogueData);
            return;
        }

        else
        {
            _dialogueManager.EndCutscene();
            _endCutscene = true;
        }
    }
}
