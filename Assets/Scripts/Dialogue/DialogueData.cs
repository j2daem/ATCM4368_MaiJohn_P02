using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue", fileName = "_DLG")]
public class DialogueData : ScriptableObject
{
    [SerializeField] private string _characterName = "...";
    [Multiline(3)] [SerializeField] private string[] _dialogue;
    //[SerializeField] private Sprite _portrait = null;

    public string CharacterName => _characterName;
    //public string Dialogue(int index) => _dialogue[index];
    public string[] Dialogues => _dialogue;
    //public Sprite Portrait => _portrait;
}
