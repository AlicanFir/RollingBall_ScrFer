using System;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private int cubesToPass;
    [SerializeField] private AudioClip doorSound;
    public int actualCubes;
    
    private void Update()
    {
        if (actualCubes >= cubesToPass)
        {
            AudioManager.instance.PlaySFX(doorSound);
            this.gameObject.SetActive(false);
            
        }
    }

}
