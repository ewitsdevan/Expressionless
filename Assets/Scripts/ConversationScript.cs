using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using Cinemachine;

public class ConversationScript : MonoBehaviour
{
    public string question;
    public string option1;
    public string option2;
    public int correctAnswer;
    public bool randomiseCorrectAnswer;

    public Canvas conversationCanvas;
    public TextMeshProUGUI dialogueText;
    public Button option1Button;
    public Button option2Button;
    public GameObject player;
    public CinemachineVirtualCamera virtualCamera;

    private bool buttonClicked;

    //When player walks upto NPC
    public void OnTriggerEnter(Collider other)
    {
        EnableCursor();

        if (other.CompareTag("Player"))
        {
            Conversation();
        }
    }

    //When player walks away
    public void OnTriggerExit(Collider other)
    {
        DisableCursor();

        conversationCanvas.enabled = false;
    }

    //Sets the UI to show correct details
    public void Conversation()
    {
        if(randomiseCorrectAnswer)
        {
            correctAnswer = Random.Range(1, 3);
        }

        conversationCanvas.enabled = true;

        option1Button.onClick.AddListener(Option1);
        option2Button.onClick.AddListener(Option2);


        dialogueText.text = question;
        option1Button.GetComponentInChildren<TextMeshProUGUI>().text = option1;
        option2Button.GetComponentInChildren<TextMeshProUGUI>().text = option2;
    }

    //When button 1 is clicked
    public void Option1()
    {
        if(buttonClicked == false)
        {

            if (correctAnswer == 1)
            {
                CorrectAnswer();
            }
            else
            {
                
                WrongAnswer();
            }

            buttonClicked = true;
            StartCoroutine(ClickDelay());
        }
    }

    //When button 2 is clicked
    public void Option2()
    {
        if(buttonClicked == false)
        {

            if (correctAnswer == 2)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }

            buttonClicked = true;
            StartCoroutine(ClickDelay());
        }
    }

    //Delay between button presses, avoids double trigger
    IEnumerator ClickDelay()
    {
        yield return new WaitForFixedUpdate();
        buttonClicked = false;
    }

    //When player gets question wrong
    public void WrongAnswer()
    {
        player.GetComponent<GameplayManager>().addWeirdness();
        player.GetComponent<AudioManager>().wrongTone();
        player.GetComponent<GameplayManager>().interactionComplete();

        DisableCursor();
        conversationCanvas.enabled = false;

        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        Destroy(gameObject);
    }

    //When player gets question right
    public void CorrectAnswer()
    {
        player.GetComponent<AudioManager>().correctTone();
        player.GetComponent<GameplayManager>().interactionComplete();

        DisableCursor();
        conversationCanvas.enabled = false;

        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        Destroy(gameObject);
    }

    //Disables the cursor for movement
    public void DisableCursor()
    {
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<FirstPersonController>().enabled = true;
        virtualCamera.LookAt = null;
    }
    
    //Enables the cursor for UI
    public void EnableCursor()
    {
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<FirstPersonController>().enabled = false;
        virtualCamera.LookAt = transform;
    }
}
