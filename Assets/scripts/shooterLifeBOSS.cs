using UnityEngine;
using System.Collections;
using TMPro;

public class shooterLifeBOSS : MonoBehaviour
{
    public GameObject UIcarta;
    public int health = 100;  
    public Transform damageTextPosition; 
    public GameObject damageText;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Vida do inimigo: " + health);
        GameObject newDamageText = Instantiate(damageText , damageTextPosition.position, Quaternion.identity);
        newDamageText.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
        Destroy(newDamageText, 1);


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