using UnityEngine;

public class KeyPurple : MonoBehaviour
{
    [SerializeField] private string keyPurple; // Ex: "PortaMasmorra"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Adiciona ao inventário do Player (vamos criar essa lógica abaixo)
            PlayerInventory.instance.AddKeyPurple(keyPurple);
            Destroy(gameObject);
        }
    }
}
