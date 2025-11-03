/*
using UnityEngine;

public class E_InstantiateFromPoints : MonoBehaviour
{
    [SerializeField] GameObject followingPart0;

    E_PlayerController player;
    E_DialogueUI dialogue;

    private void Start()
    {
        followingPart0.SetActive(false);
    }

    public void InstantiateFollowingPart()
    {
        if (dialogue.dialogueEnded == true)
        {
            if (player.positivePoint > player.negativePoint)
                followingPart0.SetActive(true);
            else if (player.positivePoint < player.negativePoint)
                Destroy(player.gameObject);
            else 
                Destroy(player.gameObject);
                // Trigger hidden dialogue line
        }
    }
}
*/