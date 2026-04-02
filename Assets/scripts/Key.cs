using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string keyMansion; // Ex: "PortaMasmorra"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Adiciona ao inventário do Player (vamos criar essa lógica abaixo)
            PlayerInventory.instance.AddKey(keyMansion);
            Destroy(gameObject);
        }
    }
}