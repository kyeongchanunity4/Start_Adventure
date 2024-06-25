using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            ChangeAlpha(GetComponent<Tilemap>(), 190);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger");
            ChangeAlpha(GetComponent<Tilemap>(), 255);
        }
    }

    private void ChangeAlpha(Tilemap tilemap, byte alpha)
    {
        if (tilemap != null)
        {
            Color color = tilemap.color;
            color.a = alpha / 255f;
            tilemap.color = color;
        }
    }
}
