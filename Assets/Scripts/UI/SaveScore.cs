using UnityEngine;
using System.IO;
using System;

public class SaveScore : MonoBehaviour
{
    private Save save = new Save();

    private string path;

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif

        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path));
        }
    }

    private void Update()
    {
        CheckScore(GameController.Instance.Score);
        Game_HUD.Instance.MaxScore.text = save.maxScore.ToString();
    }

    public void CheckScore(int score)
    {
        if (score > 0 && score > save.maxScore)
        {
            save.maxScore = GameController.Instance.Score;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            File.WriteAllText(path, JsonUtility.ToJson(save));
    }
#endif

    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }
}

[Serializable]
public class Save
{
    public int maxScore;
}