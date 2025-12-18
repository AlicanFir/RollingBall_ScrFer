using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public int life = 100;

    public int Damage(int lifePoints)
    {
        life -= lifePoints;
        Debug.Log("Me has hecho " + lifePoints + " puntos de hostia");
        Debug.Log("Me quedan " + life + " puntos de vida");

        if (life < 0)
        {
            Debug.Log("Me he morido");
            Destroy(this.gameObject);
        }
        return life;
    }
}
