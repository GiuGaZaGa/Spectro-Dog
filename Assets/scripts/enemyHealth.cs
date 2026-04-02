using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Vida do inimigo: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // O que acontece quando o inimigo morre
        
        Destroy(gameObject);
       

    }


}