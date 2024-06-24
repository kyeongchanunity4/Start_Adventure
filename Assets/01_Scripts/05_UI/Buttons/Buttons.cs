using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnMenuBtn()
    {
        UIManager.Instance.OnMenuUI();
    }
    public void OnOptionsBtn()
    {
        UIManager.Instance.OnOptionsUI();
    }
    public void OnRankingBorad()
    {
        UIManager.Instance.OnRankingUI();
    }

    public void LoadStartScene()
    {
        GameManager.Instance.OnMain();
    }
    public void StartGame()
    {
        if (!UIManager.Instance.isRankingBoard)
        {
            GameManager.Instance.OnStage1();
        }
    }
}
