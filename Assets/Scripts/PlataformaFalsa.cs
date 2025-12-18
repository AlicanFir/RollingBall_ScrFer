using System;
using UnityEngine;

public class PlataformaFalsa : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public bool isStatic = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((!isStatic) && (other.gameObject.CompareTag("Player")))
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
