using UnityEngine;

public class Boton : MonoBehaviour
{

    [SerializeField] private GameObject door;
    
    public void OpenDoor()
    {
        //Destroy(door, 2f); // se le puede meter delay al destroy
        door.SetActive(!door.activeSelf);
        //Debug.Log("Open Door");
    }
}
