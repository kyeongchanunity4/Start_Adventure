using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;

    private Rigidbody2D rb;
    public Animator anim;

    private bool isJumping;

    Vector2 jumpObjectPW = new Vector2(0, 10);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Fix YH
        float x = transform.position.x;
        float y = transform.position.y;
        transform.position = new Vector2(x, y);
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("isMove", true);
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("isMove", true);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
        if (Input.GetKey(KeyCode.K) && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            anim.SetTrigger("isAttack");
        }


        /*
        float x = transform.position.x;
        float y = transform.position.y;

        transform.position = new Vector2(x, y);
        // 방향키에 따라 캐릭터 좌우 반전
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
            anim.SetBool("isMove", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 1);
            anim.SetBool("isMove", true);
        }
        else anim.SetBool("isMove", false);

        if (Input.GetKey(KeyCode.K) && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            anim.SetTrigger("isAttack");
        }*/
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        Vector2 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;

        anim.SetBool("isAttack", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            anim.SetBool("isAttack", true);
            anim.SetBool("isMove", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JumpObject"))
        {
            rb.AddForce(jumpObjectPW, ForceMode2D.Impulse);
        }
    }
}
