using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        stageText.text = GameManager.Instance.state.ToString();
        timeText.text = GameManager.Instance.playTime.ToString("N2");
    }
}
