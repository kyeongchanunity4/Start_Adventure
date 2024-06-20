using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] private GameObject systemUI;
    [SerializeField] private TextMeshProUGUI systemText;

    public bool isContinue { get; private set; } = true;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        systemText = systemUI.GetComponentInChildren<TextMeshProUGUI>();
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

    public IEnumerator OnSystemText(string massage)
    {
        systemText.text = massage;
        systemText.color = Color.white;
        GameObject systemMassage = null;

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
        GameObject systemMassage = null;

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
