using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Atributos da Bala")]
    public float speed = 15f;
    public int damage = 15;
    public float lifetime = 3f;
    public LayerMask enemyLayer;

    void Start()
    {
        // Destruição automática
        Destroy(gameObject, lifetime);
    }
    [HideInInspector] public Vector2 direcaoVoo; // O Player vai preencher isso
    private bool direcaoDefinida = false;

    public void ConfigurarDirecao(Vector2 novaDirecao)
    {
    direcaoVoo = novaDirecao;
    direcaoDefinida = true;

    // Opcional: Gira o desenho da bala para o lado certo (X positivo ou negativo)
    float angulo = Mathf.Atan2(direcaoVoo.y, direcaoVoo.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void Update()
    {
    if (direcaoDefinida)
    {
        // Move a bala na direção exata recebida, independente de qualquer outra coisa
        transform.Translate(direcaoVoo * speed * Time.deltaTime, Space.World);
    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    // 1. Verifica se o objeto está na Layer inimiga
    if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
    {
        // 2. Tenta dar dano no Inimigo Comum
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.TakeDamage(damage);
        }
        // 3. SE NÃO FOR inimigo comum, tenta ver se é o Boss
        else if (collision.TryGetComponent<dashLifeBOSS>(out dashLifeBOSS bossDash))
        {
            bossDash.TakeDamage(damage);
        }
        else if (collision.TryGetComponent<shooterLifeBOSS>(out shooterLifeBOSS bossShooter))
        {
            bossShooter.TakeDamage(damage);
        }

        // Destrói a bala após atingir qualquer um dos dois
        Destroy(gameObject); 
    }
    }
}