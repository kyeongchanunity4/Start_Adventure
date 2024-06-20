using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void SetState(GameState gameState)
    {
        state = gameState;
    }

    // ���߿� �ε�� �߰��ϱ�
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
}