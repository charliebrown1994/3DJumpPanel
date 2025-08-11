using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    [Header("PlayerPosition")]
    [SerializeField] Rigidbody playerRb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.tag);
            playerRb.AddForce(Vector3.up * 50, ForceMode.Impulse);
        }
    }
}
