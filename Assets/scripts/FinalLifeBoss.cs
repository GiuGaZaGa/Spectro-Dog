using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalLifeBOSS : MonoBehaviour
{
    public GameObject VenceuUI;
    public GameObject portaFinal;
    public int health = 500;
   [SerializeField]
   private BarraVidafinalBoss barraVida;
   public AudioClip finish;
   public AudioSource audioS;


    public void Start(){
        this.barraVida.VidaMaxima = this.health;
        this.barraVida.Vida = this.health;

}
    public void TakeDamage(int damage)
    {
        health -= damage;

        this.barraVida.Vida = this.health;

        Debug.Log("Vida do inimigo: " + health);
                if (health <= 0)

        {
            MovPlayer.derrotouBoss = true;
            Die();
        
        }
    }

    void Die()
    {
        // O que acontece quando o inimigo morre

        gameObject.SetActive(false);
        Invoke("ShowCard", 2f);
        Debug.Log("Voce venceu");
        Invoke("HideCard", 4f);

//  GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
//          GetComponent<AudioSource>().clip = finish;
//         GetComponent<AudioSource>.Play();



    }

    void ShowCard(){

        Debug.Log("oi");
        VenceuUI.SetActive(true);

    }

    void HideCard(){

        Debug.Log("bu");
        VenceuUI.SetActive(false);

    }
}
