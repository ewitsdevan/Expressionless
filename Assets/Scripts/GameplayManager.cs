using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameplayManager : MonoBehaviour
{
    public float playerWeirdness;
    public float addWeirnessAmount;
    public int interactionsHad;

    public Slider weirdnessSlider;
    public GameObject weirdnessPanel;
    public GameObject conversationCanvas;
    public TextMeshProUGUI fadeText;
    public AudioSource musicSource;

    private bool isWeird;

    void Start()
    {
        StartCoroutine(StartText());
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Adds value to weirdness
    public void addWeirdness()
    {

        playerWeirdness = playerWeirdness + addWeirnessAmount;
        weirdnessSlider.value = playerWeirdness;

        isWeird = checkWierdness();
        if (isWeird)
        {
            endGame();
        }
    }

    //Checks if the weirdness value is maxed
    public bool checkWierdness()
    {

        if (playerWeirdness >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void interactionComplete()
    {
        interactionsHad++;

        if(interactionsHad >= 4)
        {
            endGame();
        }
    }

    //When player is weird
    public void endGame()
    {
        weirdnessPanel.SetActive(false);
        conversationCanvas.SetActive(false);
        GetComponent<AudioManager>().StopMusic();
        GetComponent<FadeAnimation>().FadeOut();

        if(isWeird)
        {
            StartCoroutine(IsWeirdEnd());
        }
        else
        {
            StartCoroutine(NotWeirdEnd());
        }
        
    }


    //Goes back to menu after waiting
    IEnumerator IsWeirdEnd()
    {
        fadeText.text = "They think you're weird.";
        yield return new WaitForSecondsRealtime(1);
        GetComponent<FadeAnimation>().TextFadeIn(fadeText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(fadeText);

        yield return new WaitForSecondsRealtime(2);
        fadeText.text = "They don't understand.";
        GetComponent<FadeAnimation>().TextFadeIn(fadeText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(fadeText);

        yield return new WaitForSecondsRealtime(4);
        Menu();
    }

    IEnumerator NotWeirdEnd()
    {
        fadeText.text = "You did it.";
        yield return new WaitForSecondsRealtime(1);
        GetComponent<FadeAnimation>().TextFadeIn(fadeText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(fadeText);

        yield return new WaitForSecondsRealtime(2);
        fadeText.text = "This time.";
        GetComponent<FadeAnimation>().TextFadeIn(fadeText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(fadeText);

        yield return new WaitForSecondsRealtime(4);
        Menu();
    }

    IEnumerator StartText()
    {
        fadeText.text = "Fit In.";
        yield return new WaitForSecondsRealtime(1);
        GetComponent<FadeAnimation>().TextFadeIn(fadeText);

        yield return new WaitForSecondsRealtime(3);
        GetComponent<FadeAnimation>().TextFadeOut(fadeText);

        yield return new WaitForSecondsRealtime(1);
        GetComponent<FadeAnimation>().StartFade();
        GetComponent<AudioSource>().Play();
        musicSource.Play();
    }

    //Menu scene loader
    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
