﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{

    public void ShareButtonClick()
    {
        StartCoroutine(TakeSSAndShare());
    }

    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "ScoreScreen.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        //new NativeShare().AddFile(filePath).SetSubject("Новый рекорд!").SetText("Мой результат!").Share();
        if (PlayerPrefs.GetString("Language") == "ru_RU")
        {
            new NativeShare().AddFile(filePath).SetSubject(LanguageSystem.Lang.setSubject).SetText(LanguageSystem.Lang.setText).Share();
        }
        else if (PlayerPrefs.GetString("Language") == "en_US")
        {
            new NativeShare().AddFile(filePath).SetSubject(LanguageSystem.Lang.setSubject).SetText(LanguageSystem.Lang.setText).Share();
        }
    }
}