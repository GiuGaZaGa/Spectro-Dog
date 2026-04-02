using UnityEngine;
using System.Collections;

public class shooterLifeBOSS : MonoBehaviour
{
    public GameObject UIcarta;
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
        
        gameObject.SetActive(false);
        Invoke("ShowCard", 2f);
        ManagerHabilidade.temShoot = true;
        Debug.Log(ManagerHabilidade.temShoot);
        Invoke("HideCard", 4f);
        
       

    }

    void ShowCard(){

        Debug.Log("oi");
        UIcarta.SetActive(true);

    }

    void HideCard(){

        Debug.Log("bu");
        UIcarta.SetActive(false);

    }

}