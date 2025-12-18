using System;
using UnityEngine;

public class PlataformaFisica : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 movementDirection;
    private Vector3 movementActual;

    [SerializeField] private float timeGoAndBack;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementDirection = new Vector3(0, 0, -1);
       
        rb.linearVelocity = movementDirection.normalized * speed; //linear velocity esta medido en metros por segundo
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        timer += Time.deltaTime;
        if (timer >= timeGoAndBack)
        {
            movementDirection *= -1;
            rb.linearVelocity = movementDirection.normalized * speed;
            timer = 0;
        }
    }
}
