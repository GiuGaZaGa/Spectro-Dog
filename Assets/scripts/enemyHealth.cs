using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject damageText;
    public Transform damageTextPosition;


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

        Destroy(gameObject);


    }


}
