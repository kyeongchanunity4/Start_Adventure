using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnMenuBtn()
    {
        UIManager.Instance.OnMenuUI();
        SoundManager.Instance.ButtonSoundPlay();
    }
    public void OnOptionsBtn()
    {
        UIManager.Instance.OnOptionsUI();
        SoundManager.Instance.ButtonSoundPlay();
    }
    public void OnRankingBorad()
    {
        UIManager.Instance.OnRankingUI();
        SoundManager.Instance.ButtonSoundPlay();
    }

    public void LoadStartScene()
    {
        GameManager.Instance.OnMain();
        SoundManager.Instance.ButtonSoundPlay();
    }

    public void RestartStage()
    {
        switch (GameManager.Instance.state)
        {
            case GameState.Stage1:
                GameManager.Instance.OnStage1();
                UIManager.Instance.ToggleContinue();
                Time.timeScale = 1.0f;
                break;
            case GameState.Stage2:
                GameManager.Instance.OnStage2();
                UIManager.Instance.ToggleContinue();
                Time.timeScale = 1.0f;
                break;
            case GameState.Stage3:
                GameManager.Instance.OnStage3();
                UIManager.Instance.ToggleContinue();
                Time.timeScale = 1.0f;
                break;
            case GameState.Boss:
                GameManager.Instance.OnStageBoss();
                UIManager.Instance.ToggleContinue();
                Time.timeScale = 1.0f;
                break;                
        }
        SoundManager.Instance.ButtonSoundPlay();
 
    }
    public void StartGame()
    {
        if (!UIManager.Instance.isRankingBoard)
        {
            GameManager.Instance.OnStage1();
            GameManager.Instance.SetEnterTime();
            SoundManager.Instance.ButtonSoundPlay();
        }
    }
}
