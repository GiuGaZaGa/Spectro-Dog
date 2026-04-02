using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float speed = 3f;
    public float detectionRange = 5f;
    
    [Header("Configurações de Ataque")]
    public int damageAmount = 1;
    public float attackCooldown = 1f;
    private float nextAttackTime;

    private Transform player;
    private Rigidbody2D rb; // Adicionado referência ao Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pega o Rigidbody ao iniciar
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void FixedUpdate() // Movimentação física deve ser no FixedUpdate
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            PerseguirPlayer();
        }
        else
        {
            // Para o inimigo se ele não estiver perseguindo, evitando que deslize
            rb.linearVelocity = Vector2.zero;
        }
    }

    void PerseguirPlayer()
    {
        Vector2 direcao = (player.position - transform.position).normalized;
        
        // MODO FÍSICO: Move usando a velocidade do Rigidbody
        rb.linearVelocity = direcao * speed;

        // Lógica do Flip (mantida)
        if (direcao.x > 0) 
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        else 
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
    }

    // ... (restante do código de dano e Gizmos permanece igual)

    // 3. Lógica de dar dano ao encostar
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica se já passou o tempo de espera para dar dano de novo
            if (Time.time >= nextAttackTime)
            {
                // Tenta pegar o script de vida do Player
                PlayerHealth playerVida = collision.gameObject.GetComponent<PlayerHealth>();
                
                if (playerVida != null)
                {
                    playerVida.TakeDamage(damageAmount);
                    nextAttackTime = Time.time + attackCooldown;
                    Debug.Log("Inimigo causou dano!");
                }
            }
        }
    }

    // Desenha o círculo de visão no editor do Unity (ajuda muito a configurar)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}