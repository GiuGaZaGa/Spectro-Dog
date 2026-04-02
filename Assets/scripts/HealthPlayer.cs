using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int maxHealth = 10;
    private int currentHealth;

    [Header("Configurações de UI")]
    public TextMeshProUGUI healthText;

    [Header("Configurações de Spawn Customizável")]
    // Arraste um GameObject vazio da hierarquia para este campo no Inspector
    public Transform pontoDeSpawnInicial; 
    private Vector3 respawnPoint;

    void Start()
    {
        currentHealth = maxHealth;

        // Se você esqueceu de arrastar um ponto no Inspector, ele usa a posição atual
        if (pontoDeSpawnInicial != null)
        {
            respawnPoint = pontoDeSpawnInicial.position;
            transform.position = respawnPoint; // Move o player para lá no início do jogo
        }
        else
        {
            respawnPoint = transform.position;
            Debug.LogWarning("Nenhum ponto de spawn definido no Inspector! Usando posição inicial.");
        }

        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    void Respawn()
    {
        Debug.Log("O jogador morreu!");
        currentHealth = maxHealth;
        UpdateHealthUI();

        // Move o jogador para o ponto salvo
        transform.position = respawnPoint;

        // Reseta a física para evitar que ele "nasça" com velocidade acumulada
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    // Função para Checkpoints (quando o player encosta em algo, o ponto de respawn muda)
    public void SetNewRespawnPoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("Novo Checkpoint alcançado!");
    }
}