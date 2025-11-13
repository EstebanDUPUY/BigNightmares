using TMPro;
// using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TalkSystem : MonoBehaviour
{
    public TalkSO currentTalkSO;
    public int currentSentenceIndex = 0;
    public int currentLineIndex = 0;
    public bool isTalking = false;
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public Image imgChara;
    // public bool isNecromancer = true;

    public GameObject[] choicesBtn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TalkNPC") && !isTalking)
        {
            currentTalkSO = collision.GetComponent<DialogContainer>().talkSO;
        }

        if (collision.CompareTag("TalkNecromancer") || collision.CompareTag("TalkBadDeath") && !isTalking)
        {
            currentTalkSO = collision.GetComponent<DialogContainer>().talkSO;
            StartCoroutine(WaitAndGameOver(5f));
        }

        if (collision.CompareTag("TalkGoodDeath") && !isTalking)
        {
            currentTalkSO = collision.GetComponent<DialogContainer>().talkSO;
            StartCoroutine(WaitAndVictory(5f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TalkNPC") || collision.CompareTag("TalkBadDeath") || collision.CompareTag("TalkGoodDeath") && !isTalking)
        {
            ResetTalk();
            currentTalkSO = null;
        }
    }

    public void Talking(InputAction.CallbackContext context)
    {
        if (context.started && currentTalkSO != null)
        {
            if (isTalking)
            {
                if (currentSentenceIndex < currentTalkSO.sentences.Length-1)
                {
                    if (currentLineIndex < currentTalkSO.sentences[currentSentenceIndex].dialogLines.Length - 1)
                    {
                        currentLineIndex++;

                    }
                    else
                    {
                        currentLineIndex = 0;
                        currentSentenceIndex++;
                    }

                    ReadLine();
                }
                else
                {

                    if (currentTalkSO.choices.Length != 0)
                    {
                        Debug.Log("current talk : " + currentTalkSO.name);
                        currentLineIndex++;
                        ReadLine();
                        ShowButton();
                    }
                    else
                    {
                        isTalking = false;
                        OpenClosePanel();
                    }
                }
            }
            else
            {
                isTalking = true;
                OpenClosePanel();
                ReadLine();
            }
        }
    }

    public void OpenClosePanel()
    {
        if (isTalking)
        {
            dialogPanel.SetActive(true);
        }
        else
        {
            dialogPanel.SetActive(false);
        }
    }

    public void ReadLine()
    {
        // Affiche la ligne en cours
        dialogText.text = currentTalkSO.sentences[currentSentenceIndex].dialogLines[currentLineIndex];
        nameText.text = currentTalkSO.sentences[currentSentenceIndex].nameTalk;
        imgChara.sprite = currentTalkSO.sentences[currentSentenceIndex].charaTalk;
    }

    public void ResetTalk()
    {
        currentLineIndex = 0;
        currentSentenceIndex = 0;
    }

    public void ShowButton() 
    {
        for (int i = 0; i < choicesBtn.Length; i++)
        {
            choicesBtn[i].gameObject.SetActive(true);
            choicesBtn[i].GetComponentInChildren<TextMeshProUGUI>().text = currentTalkSO.choices[i];
        }
    }

    public void HideButton()
    {
        foreach (GameObject btn in choicesBtn)
        {
            btn.gameObject.SetActive(false);
        }
    }
    public void ChoiceMade(int choiceIndex)
    {
        // Handle the choice made by the player
        Debug.Log("Player made choice: " + choiceIndex);
        // Reset talk system
        ResetTalk();
        HideButton();


        if (choiceIndex == 0)
        {
            currentTalkSO = currentTalkSO.goodOrNextTalkSO;
            ReadLine();
            // -> exterior event
        }

        if (choiceIndex == 1)
        {
            currentTalkSO = currentTalkSO.badTalkSO;
            ReadLine();
            // -> exterior event

        }

        if (currentTalkSO.badTalkSO == null && currentTalkSO.goodOrNextTalkSO == null)
        {
            OpenClosePanel();
            isTalking = false;
        }

    }

    private IEnumerator WaitAndGameOver(float waitTime)
    {
        //Boucle infinie
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("Attend, puis affiche " + Time.time);
            SceneManager.LoadScene("GameOver");
        }
    }
    
    private IEnumerator WaitAndVictory(float waitTime)
    {
        //Boucle infinie
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("Attend, puis affiche " + Time.time);
            SceneManager.LoadScene("Victory");
        }
    }

}