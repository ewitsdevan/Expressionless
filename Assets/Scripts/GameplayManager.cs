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
    public Image isWeirdPanel;
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

        StartCoroutine(FadeIn(1.0f, 1.0f));
        StartCoroutine(BackToMenu());
    }

    //Menu UI fade animation
    IEnumerator FadeIn(float value, float time)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color panelFade = new Color(0, 0, 0, Mathf.Lerp(0, value, t));
            isWeirdPanel.color = panelFade;

            Color textFade = new Color(1, 1, 1, Mathf.Lerp(0, value, t));
            isWeirdText.color = textFade;

            yield return null;
        }
    }

    //Goes back to menu after waiting
    IEnumerator BackToMenu()
    {
        yield return new WaitForSecondsRealtime(5);
        Menu();
    }

    //Menu scene loader
    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
