using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingBoard : MonoBehaviour
{
    private GameScoreDataList rankScore;

    [SerializeField] private GameObject rankBoard;
    [SerializeField] private GameObject nameBoard;
    [SerializeField] private GameObject scoreBoard;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        rankScore = DataManager.Instance.Load();

        if (rankScore != null)
        {
            for (int i = 0; i < rankScore.list.Count; i++)
            {
                nameText.text = (i + 1).ToString();
                Instantiate(nameText, rankBoard.transform);

                nameText.text = rankScore.list[i].name;
                Instantiate(nameText, nameBoard.transform);

                scoreText.text = rankScore.list[i].highScore.ToString("N2");
                Instantiate(scoreText, scoreBoard.transform);
            }
        }
    }
}
