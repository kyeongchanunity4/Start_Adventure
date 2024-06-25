using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Monster>(out Monster monster))
        {
            monster.TakeDamage();   
        }
    }
}
