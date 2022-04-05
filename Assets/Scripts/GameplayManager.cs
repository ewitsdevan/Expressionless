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
    public TextMeshProUGUI endText;

    private bool isWeird;

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
        endText.text = "They think you're weird.";
        yield return new WaitForSecondsRealtime(1);
        GetComponent<FadeAnimation>().TextFadeIn(endText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(endText);

        yield return new WaitForSecondsRealtime(2);
        endText.text = "They don't understand.";
        GetComponent<FadeAnimation>().TextFadeIn(endText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(endText);

        yield return new WaitForSecondsRealtime(4);
        Menu();
    }

    IEnumerator NotWeirdEnd()
    {
        endText.text = "They didn't notice.";
        yield return new WaitForSecondsRealtime(1);
        GetComponent<FadeAnimation>().TextFadeIn(endText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(endText);

        yield return new WaitForSecondsRealtime(2);
        endText.text = "This time.";
        GetComponent<FadeAnimation>().TextFadeIn(endText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(endText);

        yield return new WaitForSecondsRealtime(4);
        Menu();
    }

    //Menu scene loader
    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
