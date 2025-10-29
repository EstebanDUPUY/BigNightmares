using UnityEngine;

[CreateAssetMenu(fileName = "E_AdvancedDialogueSO", menuName = "Scriptable Objects/E_AdvancedDialogueSO")]
public class E_AdvancedDialogueSO : ScriptableObject
{
    public DialogueActors[] actors;

    [Tooltip("Only needed if Random is selected as the actor name")]
    [Header("Random Actor Info")]
    public string randomActorName;
    public Sprite randomActorPortrait;

    [Header("Dialogue")]
    [TextArea]
    public string[] dialogue;

    [Tooltip("The words that will appear on option buttons")]
    public string[] optionsText;

    public E_AdvancedDialogueSO option0;
    public E_AdvancedDialogueSO option1;
    public E_AdvancedDialogueSO option2;
    public E_AdvancedDialogueSO option3;
}
