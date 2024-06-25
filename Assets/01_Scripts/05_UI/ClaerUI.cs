using System.Collections;
using TMPro;
using UnityEngine;

public class ClaerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playTimeScore;
    [SerializeField] private TextMeshProUGUI clearStageScore;
    [SerializeField] private TextMeshProUGUI killScore;
    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private TextMeshProUGUI playerName;

    [SerializeField] private GameObject commitUI;
    [SerializeField] private GameObject saveRankUI;

    private void Start()
    {
        commitUI.SetActive(false);
        saveRankUI.SetActive(false);

        int killText = GameManager.Instance.killCount * 500;

        playTimeScore.text = GameManager.Instance.playTime.ToString("N2");
        clearStageScore.text = "5000";
        killScore.text = killText.ToString();
        totalScore.text = GameManager.Instance.GetHighScore().ToString("N1");
    }

    public void OnCommitUI()
    {
        UIManager.Instance.ToggleContinue();
        commitUI.SetActive(true);
    }
    public void OnSaveRankUI()
    {
        commitUI.SetActive(false);
        saveRankUI.SetActive(true);
    }
    public void OnSave()
    {
        if (playerName.text.Length < 2)
        {
            StartCoroutine(UIManager.Instance.OnSystemText("�̸��� �Է����ּ���!!!"));
        }
        else if (playerName.text.Length > 4)
        {
            StartCoroutine(UIManager.Instance.OnSystemText("3���� ������ �Է����ּ���!!!"));
        }
        else
        {
            StartCoroutine(CompleteSave());
        }        
    }

    public IEnumerator CompleteSave()
    {
        DataManager.Instance.SaveScore(playerName.text);
        StartCoroutine(UIManager.Instance.OnSystemText("��ŷ�� ��ϵǾ����ϴ�."));
        yield return new WaitForSeconds(1);
        GameManager.Instance.OnMain();
    }

}
