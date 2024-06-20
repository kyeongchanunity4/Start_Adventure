using System.Collections.Generic;

[System.Serializable]
public class GameScoreData
{
    public int highScore;
    public List<int> highScores = new List<int>();

    public GameScoreData(int score, List<int> ints)
    {
        highScore = score;
        highScores = ints;
    }
    public GameScoreData(int score)
    {
        highScore = score;
        highScores.Add(highScore);
    }
}
