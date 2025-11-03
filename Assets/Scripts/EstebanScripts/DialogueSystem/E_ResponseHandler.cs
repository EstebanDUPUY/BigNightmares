using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections.Generic;

public class E_ResponseHandler : MonoBehaviour
{
    [SerializeField] RectTransform responseBox;
    [SerializeField] RectTransform responseButtonTemplate;
    [SerializeField] RectTransform responseContainer;

    E_DialogueUI dialogueUI;
    [SerializeField] E_DialogueObject response;
    E_PlayerController player;

    List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<E_DialogueUI>();
    }

    public void ShowResponses(E_Response[] responses)
    {
        float responseBoxHeight = 0;

        for (int i = 0; i < responses.Length - 1; i++)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = responses[i].ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(responses[i]));
            responseButton.GetComponent<Button>().onClick.AddListener(() => SortValues(responses[i]));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    void OnPickedResponse(E_Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons) 
        { 
            Destroy(button);
        }

        dialogueUI.ShowDialogue(response.DialogueObject);
    }
    
    // problem 
    public void SortValues(E_Response response)
    {
        if (response.answerPoints > 0)
            player.positivePoint += response.answerPoints; 
        if (response.answerPoints < 0)
            player.negativePoint += response.answerPoints;
    }
}
