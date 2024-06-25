using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Main,
    Stage1,
    Stage2,
    Stage3,
    Boss,
    Over,
    Claer
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

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

    public GameState state { get; private set; } = GameState.Main;
    public float playTime { get; private set; } = 0;
    public int killCount { get; private set; } = 0;

    private void Update()
    {
        if (state != GameState.Main && state != GameState.Claer)
        {
            playTime += Time.deltaTime;
        }
    }

    public void SetState(GameState gameState)
    {
        state = gameState;
    }

    // 나중에 로드씬 추가하기
    public void OnStage1()
    {
        SceneManager.LoadScene(1);
        SetState(GameState.Stage1);
    }
    public void OnStage2()
    {
        SceneManager.LoadScene(2);
        SetState(GameState.Stage2);
    }
    public void OnStage3()
    {
        SceneManager.LoadScene(3);
        SetState(GameState.Stage3);
    }
    public void OnStageBoss()
    {
        SceneManager.LoadScene(4);
        SetState(GameState.Boss);
    }
    public void OnMain()
    {
        SceneManager.LoadScene(0);
        SetState(GameState.Main);
        UIManager.Instance.ToggleContinue();
        killCount = 0;
        playTime = 0f;
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        UIManager.Instance.OnGameOverUI();
        UIManager.Instance.ToggleContinue();
        state = GameState.Over;
        Time.timeScale = 0f;
    }
    public void GameClaer()
    {
        StartCoroutine(OnClaer());
    }

    public float GetHighScore()
    {
        float result;
        float timeScore = playTime / 5;

        if (timeScore == 0f)
        {
            timeScore = 1f;
        }

        result = (5000 + killCount * 500) / timeScore;

        return result;
    }

    public void TestScore()
    {
        for (int i = 0; i < DataManager.Instance.Load().list.Count; i++)
        {
            Debug.Log($"{DataManager.Instance.Load().list[i].highScore}, {DataManager.Instance.Load().list[i].name}");
        }
    }

    private IEnumerator OnClaer()
    {
        state = GameState.Claer;
        yield return new WaitForSeconds(3);
        UIManager.Instance.OnClaerUI();
    }
}
