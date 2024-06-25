using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    public int startHp;
    public int maxHp;
    public int currentHp;

    public GameObject hpImagePrefab;
    public Transform hpContainer;
    private List<GameObject> hpImages = new List<GameObject>();

    private void Awake()
    {
        CharacterManager.Instance.player = this;
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        startHp = maxHp;
        currentHp = startHp;

        for (int i = 0; i< currentHp; i++)
        {
            GameObject hpImage = Instantiate(hpImagePrefab, hpContainer);
            hpImages.Add(hpImage);
        }
    }

    private void Update()
    {
        if(currentHp == 0)
        {
            Time.timeScale = 0.0f;
        }
    }

    public void DecreaseHP()
    {
        if (currentHp > 0)
        {
            currentHp--;
            Destroy(hpImages[currentHp]);
            hpImages.RemoveAt(currentHp);
        }
    }

    public void IncreaseHP()
    {
        if(currentHp < maxHp)
        {
            GameObject hpImage = Instantiate (hpImagePrefab, hpContainer);
            hpImages.Insert(currentHp, hpImage);
            currentHp++;
        }
    }

    //구멍에 빠지면 게임 오버
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //구멍에 빠지면 게임 오버
        if (collision.gameObject.tag == "DropZone")
        {
            currentHp = 0;
        }

        if (collision.gameObject.tag == "NextStage")
        {
            if (SceneManager.GetActiveScene().name == "01_Stage01")
            {
                SceneManager.LoadScene("02_Stage02");
            }
            if (SceneManager.GetActiveScene().name == "02_Stage02")
            {
                SceneManager.LoadScene("03_Stage03");
            }
            if (SceneManager.GetActiveScene().name == "03_Stage03")
            {
                SceneManager.LoadScene("04_Stage04(Boss)");
            }
        }
    }
}
