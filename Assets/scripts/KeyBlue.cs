using UnityEngine;

public class KeyBlue : MonoBehaviour
{
    [SerializeField] private string keyBlue; // Ex: "PortaMasmorra"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Adiciona ao inventário do Player (vamos criar essa lógica abaixo)
            PlayerInventory.instance.AddKeyBlue(keyBlue);
            Destroy(gameObject);
        }
    }
}

