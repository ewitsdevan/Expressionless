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

    public Slider weirdnessSlider;
    public GameObject weirdnessPanel;
    public GameObject conversationCanvas;
    public TextMeshProUGUI isWeirdText;

    private bool isWeird;

    //Adds value to weirdness
    public void addWeirdness()
    {

        playerWeirdness = playerWeirdness + 0.25f;
        weirdnessSlider.value = playerWeirdness;

        isWeird = checkWierdness();
        if (isWeird)
        {
            playerIsWeird();
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

    //When player is weird
    public void playerIsWeird()
    {

        weirdnessPanel.SetActive(false);
        conversationCanvas.SetActive(false);
        GetComponent<AudioManager>().StopMusic();

        GetComponent<FadeAnimation>().FadeOut();
        StartCoroutine(BackToMenu());
    }


    //Goes back to menu after waiting
    IEnumerator BackToMenu()
    {
        yield return new WaitForSecondsRealtime(1);
        GetComponent<FadeAnimation>().TextFadeIn(isWeirdText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(isWeirdText);

        yield return new WaitForSecondsRealtime(2);
        isWeirdText.text = "They don't understand.";
        GetComponent<FadeAnimation>().TextFadeIn(isWeirdText);

        yield return new WaitForSecondsRealtime(4);
        GetComponent<FadeAnimation>().TextFadeOut(isWeirdText);

        yield return new WaitForSecondsRealtime(4);
        Menu();
    }

    //Menu scene loader
    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
