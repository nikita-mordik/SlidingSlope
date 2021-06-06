using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHUD : MonoBehaviour
{
    public Button ENGButton;
    public Button RUSButton;
    public GameObject select;

    public GameObject soundOn;
    public GameObject soundOff;

    public Text playText;
    public Text[] turnText;
    public Text[] evedeText;
    public Text pickUpText;
    public Text backText;

    private void Start()
    {
        //при возвращении или при первом запуске проверяю какой ключ стоит или какой системный язык и показываю соответствующий язык:
        for (int i = 0; i < 2; i++)
        {
            if (PlayerPrefs.GetString("Language") == "ru_RU")
            {
                select.transform.position = RUSButton.transform.position;
                playText.text = LanguageSystem.Lang.play;
                turnText[i].text = LanguageSystem.Lang.tap;
                evedeText[i].text = LanguageSystem.Lang.evede;
                pickUpText.text = LanguageSystem.Lang.pickUp;
                backText.text = LanguageSystem.Lang.back;
            }
            else if(PlayerPrefs.GetString("Language") == "en_US")
            {
                select.transform.position = ENGButton.transform.position;
                playText.text = LanguageSystem.Lang.play;
                turnText[i].text = LanguageSystem.Lang.tap;
                evedeText[i].text = LanguageSystem.Lang.evede;
                pickUpText.text = LanguageSystem.Lang.pickUp;
                backText.text = LanguageSystem.Lang.back;
            }
        }

        if (AudioListener.volume == 1.0f)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else if (AudioListener.volume == 0.0f)
        {
            soundOff.SetActive(true);
            soundOn.SetActive(false);
        }
    }

    public void ENGButtonSelect()
    {
        select.transform.position = ENGButton.transform.position;  //подсвечиваю выбраную кнопку
        playText.text = LanguageSystem.Lang.play;
        for (int i = 0; i < turnText.Length; i++)
        {
            turnText[i].text = LanguageSystem.Lang.tap;
            evedeText[i].text = LanguageSystem.Lang.evede;
        }
        pickUpText.text = LanguageSystem.Lang.pickUp;
        backText.text = LanguageSystem.Lang.back;
    }

    public void RUSButtonSelect()
    {
        select.transform.position = RUSButton.transform.position;
        playText.text = LanguageSystem.Lang.play;
        for (int i = 0; i < turnText.Length; i++)
        {
            turnText[i].text = LanguageSystem.Lang.tap;
            evedeText[i].text = LanguageSystem.Lang.evede;
        }
        pickUpText.text = LanguageSystem.Lang.pickUp;
        backText.text = LanguageSystem.Lang.back;
    }

    public void SoundSetting()
    {
        if (soundOn.activeInHierarchy)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0.0f;
        }
        else if (soundOff.activeInHierarchy)
        {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
            AudioListener.volume = 1.0f;
        }
    }

    public void PrivacyPolicySelect()
    {
        //перехож по ссылке - https://docs.google.com/document/d/1EeeNMfF1EIwzLjEvVRValjyJIInFKHYQJsd_A07TAUk/edit
        Application.OpenURL("https://docs.google.com/document/d/1EeeNMfF1EIwzLjEvVRValjyJIInFKHYQJsd_A07TAUk/edit");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}