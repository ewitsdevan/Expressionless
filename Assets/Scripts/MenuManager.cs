using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;

    public Slider volumeSlider;
    public TMP_Dropdown qualityDropdown;
    public TextMeshProUGUI versionText;

    public void Play()
    {
        GetComponent<FadeAnimation>().FadeOut();
        StartCoroutine(PlayE());
    }

    IEnumerator PlayE()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);

        qualityDropdown.value = QualitySettings.GetQualityLevel();
        versionText.text = Application.version;
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Volume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void Quality()
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value);
    }
}
