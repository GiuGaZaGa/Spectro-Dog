using UnityEngine;
using System.Collections;

public class dashLifeBOSS : MonoBehaviour
{
    public GameObject UIcarta;
    public int health = 100;
    public GameObject damageText;
    public Transform damageTextPosition;
    

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
        MovPlayer.temDash = true;
        Debug.Log(MovPlayer.temDash);
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