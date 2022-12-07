using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] DialogueManager _dialogueManager;
    [SerializeField] public DialogueData[] _dialogueArray = new DialogueData[5];
    [SerializeField] int _dialogueArraySize;
    [SerializeField] public GameObject _pauseMenu;
    [SerializeField] string _nextSceneName;
    private DialogueData _activeDialogueData;
    private int _dialogueIndex;
    private bool _endCutscene;
    private PlayerInput _playerInput;

    private void Start()
    {
        _dialogueIndex = 0;
        _endCutscene = false;
        //_playerInput = GetComponent<PlayerInput>();

        //_playerInput.onActionTriggered += PlayerInput_onActionTriggered;

        // Assign active dialogue and pass to manager if valid
        if (_dialogueArray.Length > 0)
        {
            _activeDialogueData = _dialogueArray[_dialogueIndex];
            _dialogueManager.StartDialogue(_activeDialogueData);
        }
    }

    public void ProgressCutscene(InputAction.CallbackContext context)
    {
        if (context.performed)
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
    }

    public void ContinueCutscene(InputAction.CallbackContext context)
    {
        if (context.performed && _endCutscene)
        {
            // Reconsider loading a specific scene by name / string
            int currentActiveSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(_nextSceneName);
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_pauseMenu.activeInHierarchy != true)
            {
                _pauseMenu.SetActive(true);
            }

            else
            {
                _pauseMenu.SetActive(false);
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
