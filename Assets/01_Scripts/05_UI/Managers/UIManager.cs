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

    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject optionsUI;

    public bool isContinue { get; private set; } = true;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
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
}
