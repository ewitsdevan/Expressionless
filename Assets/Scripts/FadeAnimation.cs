using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeAnimation : MonoBehaviour
{
    public Image fadeImage;

    void Start()
    {
        StartCoroutine(FadeInE(0f, 1.0f));
    }

    IEnumerator FadeInE(float value, float time)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color panelFade = new Color(0, 0, 0, Mathf.Lerp(1, value, t));
            fadeImage.color = panelFade;

            yield return null;
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutE(1.0f, 1.0f));
    }

    IEnumerator FadeOutE(float value, float time)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color panelFade = new Color(0, 0, 0, Mathf.Lerp(0, value, t));
            fadeImage.color = panelFade;

            yield return null;
        }
    }
    

    public void TextFadeIn(TextMeshProUGUI tmp)
    {
        StartCoroutine(TextFadeInE(1f, 1.0f, tmp));
    }

    IEnumerator TextFadeInE(float value, float time, TextMeshProUGUI uiText)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color panelFade = new Color(1, 1, 1, Mathf.Lerp(0, value, t));
            uiText.color = panelFade;

            yield return null;
        }
    }
}
