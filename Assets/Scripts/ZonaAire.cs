using System;
using UnityEngine;

public class ZonaAire : MonoBehaviour
{
    //las variables que estan aqui deberian ser solo del objeto y las de otros objetos dentro de las funciones
    [SerializeField] private float force;
    private void OnTriggerStay(Collider other) //por cada ciclo de fisicas
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            otherRb.AddForce(new Vector3(0, force, 0), ForceMode.Force);
        }
    }
}
