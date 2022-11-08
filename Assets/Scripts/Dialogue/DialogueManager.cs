using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _characterNameHolder;
    [SerializeField] private TextMeshProUGUI _dialogueHolder;

    private int _dialogueIndex = 0;
    private bool _dialogueStarted = false;
    /*private bool _dialogueEnded = false;
    public bool DialogueEnded => _dialogueEnded;*/
    private Queue<string> sentences;

    public bool DialogueStarted => _dialogueStarted;

    //Initialization
    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        _dialogueStarted = true;
        _characterNameHolder.text = dialogueData.CharacterName;

        sentences.Clear();

        foreach (string _dialogue in dialogueData.Dialogues){
            sentences.Enqueue(_dialogue);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        _dialogueHolder.text = sentence;
    }

    public void EndDialogue()
    {
        _dialogueStarted = true;
        //_dialogueEnded = true;
    }
}
