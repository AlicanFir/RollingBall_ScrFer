using System;
using UnityEngine;

public class GoldenCube : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private float rotationspeed = 0;
    
    [SerializeField] private AudioClip coinSound;
    [SerializeField] public DoorScript doorScript;

    private void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up *(rotationspeed*Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(coinSound);
            doorScript.actualCubes += 1;
            Destroy(this.gameObject);
        }
        
    }
}
