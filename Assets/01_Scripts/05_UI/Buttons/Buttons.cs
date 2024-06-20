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

    public void LoadStartScene()
    {
        GameManager.Instance.SetState(GameState.Main);
        SceneManager.LoadScene(0);
    }
}
