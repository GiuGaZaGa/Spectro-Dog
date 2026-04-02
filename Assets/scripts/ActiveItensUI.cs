using UnityEngine;

public class ActiveItensUI : MonoBehaviour
{
    public GameObject Chave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Chave != null)
        {
            Chave.SetActive(false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("ChavePorta")){


        Chave.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
