using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

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

    private GameObject canvas;

    private GameObject menuObj = null;
    private GameObject optionsObj = null;
    private GameObject rankingObj = null;

    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject systemUI;
    [SerializeField] private GameObject rankingBoard;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject clearUI;
    [SerializeField] private TextMeshProUGUI systemText;

    public bool isContinue { get; private set; } = true;
    public bool isRankingBoard { get; private set; } = false;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        systemText = systemUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ToggleContinue()
    {
        if (GameManager.Instance.state == GameState.Main)
        {
            isContinue = true;
        }
        else if(isContinue)
        {
            isContinue = false;
        }
        else
        {
            isContinue = true;
        }
    }
    public void OnMenuUI()
    {
        if (menuObj == null)
        {
            if (canvas == null)
            {
                canvas = GameObject.Find("Canvas");
            }
            menuObj = Instantiate(menuUI, canvas.transform);
            isContinue = false;
            Time.timeScale = 0f;
        }
        else
        {
            Destroy (menuObj);
            isContinue = true;
            Time.timeScale = 1.0f;
        }
    }

    public void OnOptionsUI()
    {
        if (optionsObj == null)
        {
            if (canvas == null)
            {
                canvas = GameObject.Find("Canvas");
            }
            optionsObj = Instantiate(optionsUI, canvas.transform);
        }
        else
        {
            Destroy(optionsObj);
        }
    }
    public void OnGameOverUI()
    {
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }
        Instantiate(gameOverUI, canvas.transform);
    }
    public void OnClaerUI()
    {
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }
        Instantiate(clearUI, canvas.transform);
    }

    public void OnRankingUI()
    {
        if (rankingObj == null)
        {
            if (canvas == null)
            {
                canvas = GameObject.Find("Canvas");
            }
            rankingObj = Instantiate(rankingBoard, canvas.transform);
            isRankingBoard = true;
        }
        else
        {
            Destroy(rankingObj);
            isRankingBoard = false;
        }
    }

    public IEnumerator OnSystemText(string massage)
    {
        systemText.text = massage;
        systemText.color = Color.white;
        GameObject systemMassage;

        GameObject pastText = GameObject.Find("SystemUI(Clone)");
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }
        if (pastText != null)
        {
            Destroy(pastText);
        }
        systemMassage = Instantiate(systemUI, canvas.transform);

        yield return new WaitForSeconds(2);

        if (systemMassage != null )
        {
            Destroy(systemMassage);
        }
    }

    public IEnumerator OnSystemText(string massage, Color color)
    {
        systemText.text = massage;
        systemText.color = color;
        GameObject systemMassage;

        GameObject pastText = GameObject.Find("SystemUI(Clone)");
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }
        if (pastText != null)
        {
            Destroy(pastText);
        }
        systemMassage = Instantiate(systemUI, canvas.transform);

        yield return new WaitForSeconds(2);

        if (systemMassage != null)
        {
            Destroy(systemMassage);
        }
    }
}
