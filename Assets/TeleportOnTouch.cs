using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTouch : MonoBehaviour
{
    public Transform initialPosition;  // ��������� ������� ������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // ��������������, ��� ����� ����� ��� "Player"
        {
            other.transform.position = initialPosition.position;
        }
    }
}

