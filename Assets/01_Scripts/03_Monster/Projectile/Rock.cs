using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public readonly int isExplode = Animator.StringToHash("isExplode");

    public float speed = 5f;
    public LayerMask layer;
    private Animator anim;
    private Rigidbody2D rigid;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & layer) != 0)
        {
            Debug.Log("Rock Trigger!");
            anim.SetTrigger(isExplode);
            rigid.velocity = Vector3.zero;
        }
    }

    public void OnEnterNextScene()
    {
        Destroy(gameObject);
    }
}
