using UnityEngine;

public enum GameState
{
    Main,
    Stage1,
    Stage2,
    Stage3,
    Boss,
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

    public int curScore;

    public void SetState(GameState gameState)
    {
        state = gameState;
    }

    // 나중에 로드씬 추가하기
    public void OnStage1()
    {
        SetState(GameState.Stage1);
    }
    public void OnStage2()
    {
        SetState(GameState.Stage2);
    }
    public void OnStage3()
    {
        SetState(GameState.Stage3);
    }
    public void OnStageBoss()
    {
        SetState(GameState.Boss);
    }

    public int GetHighScore()
    {
        return curScore;
    }

    public void TestScore()
    {
        for (int i = 0; i < DataManager.Instance.Load().list.Count; i++)
        {
            Debug.Log($"{DataManager.Instance.Load().list[i].highScore}, {DataManager.Instance.Load().list[i].name}");
        }
    }
}
