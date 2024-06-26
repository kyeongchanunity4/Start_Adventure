using System.Collections.Generic;
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

    GameScoreDataList highScores;


    private string SavePath => Application.persistentDataPath + "/saves/";

    private void SaveScoreData(GameScoreDataList gameData)
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
    public GameScoreDataList Load()
    {
        string saveFilePath = SavePath + "GameData" + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("No such saveFile exists");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        GameScoreDataList saveData = JsonUtility.FromJson<GameScoreDataList>(saveFile);
        return saveData;
    }

    public void SaveScore(string str)
    {        
        GameScoreData newScore = new GameScoreData(GameManager.Instance.GetHighScore(), str);

        if (Load() == null)
        {
            List<GameScoreData> newData = new List<GameScoreData>();
            highScores = new GameScoreDataList(newData);
            highScores.list.Add(newScore);

            SaveScoreData(highScores);
        }
        else
        {
            highScores = Load();
            highScores.list.Add(newScore);

            for (int i = 0; i < highScores.list.Count - 1; i++)
            {
                for (int j = i + 1; j < highScores.list.Count; j++)
                {
                    if (highScores.list[i].highScore < highScores.list[j].highScore)
                    {
                        GameScoreData temp = highScores.list[j];
                        highScores.list[j] = highScores.list[i];
                        highScores.list[i] = temp;
                    }
                }
            }
            while (highScores.list.Count > 5)
            {
                for (int i = 0; i < highScores.list.Count; i++)
                {
                    if (i >= 5)
                    {
                        highScores.list.Remove(highScores.list[i]);
                    }
                }
            }
            SaveScoreData(highScores);
        }
    }
}
