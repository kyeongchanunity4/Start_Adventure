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

    private void FixedUpdate()
    {
        if(currentHp == 0)
        {
            GameManager.Instance.GameOver();
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
    }
}
