using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTouch : MonoBehaviour
{
    public Transform initialPosition;  // Начальная позиция игрока

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Предполагается, что игрок имеет тег "Player"
        {
            other.transform.position = initialPosition.position;
        }
    }
}

