using UnityEngine;
using UnityEngine.SceneManagement;
public class Box : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            GetComponent<SpriteRenderer>().enabled = false;

            Invoke ("CarregaScene", 1f);
            
        }
    }

    void CarregaScene(){


         SceneManager.LoadScene("CSCaixa1");
    }
}
