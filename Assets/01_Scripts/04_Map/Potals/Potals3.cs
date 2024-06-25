using UnityEngine;

public class Potals3 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.SetEnterTime();
        GameManager.Instance.OnStageBoss();
    }
}
