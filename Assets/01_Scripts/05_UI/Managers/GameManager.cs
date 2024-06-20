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


}
