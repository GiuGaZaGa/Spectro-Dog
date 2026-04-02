using UnityEngine;

// Coloque este script em um objeto com Trigger
public class Checkpoint : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            // Atualiza o ponto de respawn para a posição deste checkpoint
            other.GetComponent<PlayerHealth>().SetNewRespawnPoint(transform.position);
        }
    }
}
