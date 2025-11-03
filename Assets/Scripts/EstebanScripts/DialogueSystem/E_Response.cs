using UnityEngine;

[System.Serializable]
public class E_Response
{
    [SerializeField] string responseText;
    [SerializeField] E_DialogueObject dialogueObject;

    //
    public int answerPoints;

    public string ResponseText => responseText;

    public E_DialogueObject DialogueObject => dialogueObject;
}
