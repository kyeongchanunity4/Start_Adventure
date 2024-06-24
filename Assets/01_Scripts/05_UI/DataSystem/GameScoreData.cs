using System.Collections.Generic;

[System.Serializable]
public class GameScoreData
{
    public float highScore;
    public string name;

    public GameScoreData(float score, string str)
    {
        highScore = score;
        name = str;
    }
}

[System.Serializable]
public class GameScoreDataList
{
    public List<GameScoreData> list;

    public GameScoreDataList(List<GameScoreData> data)
    {
        list = data;
    }
}
