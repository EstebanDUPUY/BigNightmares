using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class E_Dialogue : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] TMP_Text speakerText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Image portraitImage;

    [Header("Dialogue Content")]
    [SerializeField] string[] speaker;
    [TextArea][SerializeField] string[] dialogueWords;
    [SerializeField] Sprite[] portrait;

    int step;
    bool dialogueActivate;
    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && dialogueActivate)
        {
            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
                step = 0; 
            }
            else
            {
                dialogueCanvas.SetActive(true);
                speakerText.text = speaker[step];
                dialogueText.text = dialogueWords[step];
                portraitImage.sprite = portrait[step];
                step++;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            dialogueActivate = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueActivate = false;
        dialogueCanvas.SetActive(false);
    }
}
