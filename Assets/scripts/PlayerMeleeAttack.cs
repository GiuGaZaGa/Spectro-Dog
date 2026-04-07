using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Configurações Melee")]
    public Transform attackPoint;    
    public float attackRange = 1.2f; 
    public int damage = 25;          
    public LayerMask enemyLayer;     
    public float attackCooldown = 0.4f;
    public Animator animator;
    
    private float nextAttackTime;

    void Update()
    {
        // O ataque só acontece quando o botão é pressionado
        if (Input.GetButtonDown("Fire1") && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
          
        }
    }

    void Attack()
    {
        // Calculamos a diferença de posição
        Vector3 diferenca = attackPoint.position - transform.position;

        // Criamos a direção usando apenas o X da diferença, e travamos o Y em 0
        // Usamos Mathf.Sign para garantir que o valor seja sempre 1 ou -1
        Vector2 direcaoHorizontal = new Vector2(Mathf.Sign(diferenca.x), 0);

        // Agora o Raycast será sempre uma linha reta horizontal
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direcaoHorizontal, attackRange, enemyLayer);

        // Debug visual para conferir a linha reta
        Debug.DrawRay(attackPoint.position, direcaoHorizontal * attackRange, Color.red, 0.2f);

        if(Input.GetButtonDown("Fire1")){
            animator.SetBool("isBite", true);
        }
        if(Input.GetButtonUp("Fire1")){

            animator.SetBool("isBite", false);
        }

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {
                enemy.TakeDamage(damage);
            
            }
            // 3. SE NÃO FOR inimigo comum, tenta ver se é o Boss
            else if (hit.collider.TryGetComponent<dashLifeBOSS>(out dashLifeBOSS bossDash))
            {
                bossDash.TakeDamage(damage);
            }
            else if (hit.collider.TryGetComponent<shooterLifeBOSS>(out shooterLifeBOSS bossShooter))
            {
                bossShooter.TakeDamage(damage);
            }
            else if (hit.collider.TryGetComponent<FinalLifeBOSS>(out FinalLifeBOSS finalBoss))
            {
                finalBoss.TakeDamage(damage);
            }

            // Destrói a bala após atingir qualquer um dos dois
        
        }

    }
    public void EndAtack(){

        animator.SetBool("isBite", false);

    }
}