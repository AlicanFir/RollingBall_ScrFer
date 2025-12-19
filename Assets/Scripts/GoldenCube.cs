using System;
using UnityEngine;

public class GoldenCube : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private float rotationspeed = 0;
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] public DoorScript doorScript;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up *(rotationspeed*Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //audioSource.Play();
            doorScript.actualCubes += 1;
            Destroy(this.gameObject);
        }
        
    }
}
