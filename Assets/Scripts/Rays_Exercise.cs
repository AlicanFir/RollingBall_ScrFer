using System;
using UnityEngine;

public class Rays_Exercise : MonoBehaviour
{

    [SerializeField] private float distance;
    [SerializeField] private int damage;
    [SerializeField] private int radius;
    [SerializeField] private int strength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayHitFuncion();
        }

        if (Input.GetMouseButton(1))
        {
            OverlapFuncion();
        }
    }

    void RayHitFuncion()
    {
        RaycastHit impactInfo;
        if (Physics.Raycast(transform.position, Vector3.forward, out impactInfo))
        {
            Debug.DrawRay(transform.position, Vector3.forward * distance, Color.red, 2f); //tiene que chocar contra algo

            Rigidbody rbHit = impactInfo.rigidbody;
            Debug.Log(rbHit);
            
            rbHit.GetComponent<Enemy>().Damage(10);
        }
    } //calcula el raycast

    void OverlapFuncion()
    {
        Collider[] collidersWithRadius = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in collidersWithRadius)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(strength, transform.position, radius);
            }
        }
    }
}