using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LanguageSystem : MonoBehaviour
{
    private static LanguageSystem m_instance;
    public static LanguageSystem m_Instance { get => m_instance; }

    private string json;

    public static Lang Lang = new Lang();

    [HideInInspector] public int indexLang = 1;
    private string[] languageArray = { "ru_RU", "en_US" };

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        
        if (!PlayerPrefs.HasKey("Language"))
        {
            //if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian
            //    || Application.systemLanguage == SystemLanguage.Belarusian)
            //{
            //    PlayerPrefs.SetString("Language", "ru_RU");
            //}
            if (Application.systemLanguage != SystemLanguage.English)
            {
                PlayerPrefs.SetString("Language", "ru_RU");
            }
            else PlayerPrefs.SetString("Language", "en_US");
        }

        LanguageLoad();
    }

    public void LanguageLoad()
    {
#if UNITY_ANDROID && !UNITY_EDITOR || UNITY_REMOTE
                string path = Path.Combine(Application.streamingAssetsPath, "Languages/" + PlayerPrefs.GetString("Language") + ".json");
                WWW reader = new WWW(path);
                while (!reader.isDone) { }
                json = reader.text;
                Lang = JsonUtility.FromJson<Lang>(json);
#endif

#if UNITY_EDITOR
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");

        Lang = JsonUtility.FromJson<Lang>(json);
#endif
    }

    public void SwitchLanguage(int langIndex)
    {
        indexLang = langIndex;
        if (langIndex != languageArray.Length)
            langIndex++;
        else langIndex = 1;

        PlayerPrefs.SetString("Language", languageArray[langIndex - 1]);

        LanguageLoad();
    }
}

public class Lang
{
    //поля которые будут переводиться:
    public string play;
    public string back;
    public string evede;
    public string tap;
    public string pickUp;
    public string bestScore;
    public string share;
    public string mainMenu;
    public string restart;
}