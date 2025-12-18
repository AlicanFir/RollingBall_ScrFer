using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Cylinder : MonoBehaviour
{ 
    [SerializeField] private float rotationForce;
    [SerializeField] private Vector3 direction;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(direction * rotationForce, ForceMode.VelocityChange);
    }
}
