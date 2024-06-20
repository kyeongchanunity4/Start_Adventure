using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViweCurStateUI : MonoBehaviour
{
    [SerializeField] private GameObject stg1;
    [SerializeField] private GameObject stg2;
    [SerializeField] private GameObject stg3;
    [SerializeField] private GameObject stg4;

    [SerializeField] private GameObject stg1Tag;
    [SerializeField] private GameObject stg2Tag;
    [SerializeField] private GameObject stg3Tag;
    [SerializeField] private GameObject stg4Tag;

    private List<GameObject> stags;
    private List<GameObject> tags;

    private void Awake()
    {
        stags = new List<GameObject>
        {
            stg1,
            stg2,
            stg3,
            stg4
        };

        tags = new List<GameObject>
        {
            stg1Tag,
            stg2Tag,
            stg3Tag,
            stg4Tag
        };
    }
    private void Start()
    {
        for (int i = 0; i < stags.Count; i++)
        {
            int curState = (int)GameManager.Instance.state;
            if (curState > i + 1)
            {
                stags[i].GetComponent<Image>().color = new Color(1, 100 / 255 / 100 / 255, 1);
            }
            else if (curState == i + 1)
            {
                tags[i].gameObject.SetActive(true);
            }
        }
    }
}
