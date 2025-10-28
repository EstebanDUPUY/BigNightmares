
using UnityEngine;
using TMPro;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class E_DialogueManager : MonoBehaviour
{

    [SerializeField]
    GameObject dialoguePanel;

    [SerializeField]
    TextMeshProUGUI dialogueText;

    [SerializeField]
    GameObject buttonPrefab;

    [SerializeField]
    Transform buttonsParent;

    [SerializeField]
    E_PlayerController playerController;

    public void BeginDialogue(E_DialogueSO dialogue)
    {
        if (dialogue.Choices.Count == 0)
        {
            dialoguePanel.SetActive(false);

            playerController.ToggleMovement(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            return;
        }

        playerController.ToggleMovement(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialoguePanel.SetActive(true);

        ClearChoices();
        AnimateText(dialogue);
    }

    void AnimateText(E_DialogueSO dialogue)
    {
        IEnumerator TypeText(string text)
        {
            StringBuilder textToShow = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                textToShow.Append(text[i]);
                dialogueText.text = textToShow.ToString();

                yield return new WaitForSeconds(1f / 20f);
            }
            ShowChoices(dialogue);
        }

        StartCoroutine(TypeText(dialogue.DialogueText));
    }

    void ShowChoices(E_DialogueSO dialogue)
    {
        foreach (E_DialogueSO choice in dialogue.Choices)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonsParent);

            newButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.OptionName;
            newButton.GetComponent<Button>().onClick.AddListener(() => {
                BeginDialogue(choice);
            });
        }
    }

    void ClearChoices()
    {
        foreach (Transform child in buttonsParent)
        {
            Destroy(child.gameObject);
        }
    }



}
