using UnityEngine;
using UnityEngine.SceneManagement;

public class portaFinal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(MovPlayer.derrotouBoss){

            GetComponent<Collider2D>().isTrigger = true;

        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player") && MovPlayer.derrotouBoss)
        {

            CarregarCena();
            Debug.Log("Comparou");

        }

    }
    void CarregarCena()
    {

        SceneManager.LoadScene("Queda1");
        Debug.Log("Chegou Aqui");

    }
}
