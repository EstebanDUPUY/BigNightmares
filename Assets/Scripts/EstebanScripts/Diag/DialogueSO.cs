using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/DialogueSO")]
public class DialogueSO : ScriptableObject
{
    public List<Dialogue> dialogueContainer = new();
}
