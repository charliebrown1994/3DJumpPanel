using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    [SerializeField] private float jumpPower = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.tag);

            Rigidbody rigid = other.GetComponent<Rigidbody>();

            if (rigid != null)
            {
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}
