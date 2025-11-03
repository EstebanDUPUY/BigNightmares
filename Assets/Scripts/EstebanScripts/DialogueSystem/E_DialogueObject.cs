using UnityEngine;

[CreateAssetMenu(fileName = "E_DialogueObject", menuName = "Scriptable Objects/E_DialogueObject")]
public class E_DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] string[] dialogue;
    public E_Response[] responses;

    public string[] Dialogue => dialogue;

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public E_Response[] Responses => responses;
}
