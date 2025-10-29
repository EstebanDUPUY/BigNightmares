using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class E_AdvancedDialogueManager : MonoBehaviour
{
    // The NPC Dialogue we are currently stepping through
    E_AdvancedDialogueSO currentConversation;
    int stepNum;

    // UI References
    GameObject dialogueCanvas;
    TMP_Text actor;
    Image portrait;
    TMP_Text dialogueText;

    void Start()
    {
        dialogueCanvas = GameObject.Find("DialogueCanvas");
        actor = GameObject.Find("ActorText").GetComponent<TMP_Text>();
        portrait = GameObject.Find("Portrait").GetComponent<Image>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
    }

    public void InitiateDialogue(E_NPCDialogue npcDialogue)
    {
        // the array that we are currently stepping through
        currentConversation = npcDialogue.conversation[0];
        // Debug
        Debug.Log("Started Conversation " + currentConversation);
    }

    public void TurnOffDialogue()
    {
        stepNum = 0;
        // Debug
        Debug.Log("Ended conversation. Reset the step to " + stepNum);
    }
}

public enum DialogueActors
{
    Actor0,
    Actor1,
    Actor2,
    Actor3
};  
