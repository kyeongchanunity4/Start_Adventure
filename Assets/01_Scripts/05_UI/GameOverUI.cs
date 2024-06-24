using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Start()
    {
        scoreText.text = GameManager.Instance.GetHighScore().ToString("N1");
        timeText.text = GameManager.Instance.playTime.ToString("N2");
    }
}
