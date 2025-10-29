using UnityEngine;

[CreateAssetMenu(fileName = "E_DialogueObject", menuName = "Scriptable Objects/E_DialogueObject")]
public class E_DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] string[] dialogue;
    [SerializeField] E_Response[] responses;

    public string[] Dialogue => dialogue;

    public E_Response[] Responses => responses;
}
