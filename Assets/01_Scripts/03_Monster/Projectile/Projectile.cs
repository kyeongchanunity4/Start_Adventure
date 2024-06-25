using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;

    public LayerMask layer;

    public void Init(Vector3 dir)
    {
        this.direction = dir.normalized;
    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & layer) != 0)
        {
            if(other.TryGetComponent<Player>(out Player player))
            {
                player.DecreaseHP();
            }
            Destroy(gameObject);
        }
    }
}
