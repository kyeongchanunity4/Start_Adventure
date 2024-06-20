using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public string SavePath => Application.persistentDataPath + "/saves/";

    public void SaveScoreData(GameScoreData gameData)
    {
        string saveFilePath = SavePath + "GameData" + ".json";

        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }

        string saveJson = JsonUtility.ToJson(gameData);

        File.WriteAllText(saveFilePath, saveJson);

        Debug.Log("Save Success: " + saveFilePath);
    }
    public GameScoreData Load()
    {
        string saveFilePath = SavePath + "GameData" + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("No such saveFile exists");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        GameScoreData saveData = JsonUtility.FromJson<GameScoreData>(saveFile);
        return saveData;
    }

    public void SaveScore()
    {
        GameScoreData saveScore = new GameScoreData(GameManager.Instance.GetHighScore());

        if (Load() == null)
        {
            SaveScoreData(saveScore);
        }
        else
        {
            GameScoreData newScore = Load();
            newScore.highScores.Add(GameManager.Instance.GetHighScore());

            for (int i = 0; i < newScore.highScores.Count - 1; i++)
            {
                for (int j = i + 1; j < newScore.highScores.Count; j++)
                {
                    if (newScore.highScores[i] < newScore.highScores[j])
                    {
                        int temp = newScore.highScores[j];
                        newScore.highScores[j] = newScore.highScores[i];
                        newScore.highScores[i] = temp;
                    }
                }
            }
            while (newScore.highScores.Count > 5)
            {
                for (int i = 0; i < newScore.highScores.Count; i++)
                {
                    if (i >= 5)
                    {
                        newScore.highScores.Remove(newScore.highScores[i]);
                    }
                }
            }
            SaveScoreData(newScore);
        }
    }
}
