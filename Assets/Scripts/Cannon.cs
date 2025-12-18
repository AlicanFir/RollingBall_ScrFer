using UnityEngine;

public class Cannon : MonoBehaviour
{
    //spawnear bolitas cada x tiempo
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    
    
    void Start()
    {

        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
