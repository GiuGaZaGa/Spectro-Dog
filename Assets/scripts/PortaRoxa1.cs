using UnityEngine;

public class DoorPurple : MonoBehaviour
{
    public string keyNeeded; // Deve ser igual ao keyName da chave

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerInventory.instance.HasKeyPurple(keyNeeded))
            {
                Debug.Log("Porta Aberta!");
                // Aqui você pode rodar uma animação ou simplesmente sumir com a porta
                gameObject.SetActive(false); 
            }
            else
            {
                Debug.Log("Você precisa de uma chave!");
            }
        }
    }

}