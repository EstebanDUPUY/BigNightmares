using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue", fileName = "New Dialogue")]
public class E_DialogueSO : ScriptableObject
{
    [SerializeField] List<E_DialogueSO> choices = new List<E_DialogueSO>();

    [SerializeField] string optionName;
    [SerializeField] string dialogueText;

    public string OptionName
    {
        get
        {
            return optionName;
        }
    }

    public List<E_DialogueSO> Choices
    {
        get
        {
            return choices;
        }
    }

    public string DialogueText
    {
        get
        {
            return dialogueText;
        }
    }
}