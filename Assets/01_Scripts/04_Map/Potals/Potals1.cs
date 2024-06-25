using UnityEngine;

public class Potals1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.SetEnterTime();
        GameManager.Instance.OnStage2();
    }
}
