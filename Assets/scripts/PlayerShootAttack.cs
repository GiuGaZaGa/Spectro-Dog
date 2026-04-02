using UnityEngine;

public class PlayerShootAttack : MonoBehaviour
{
    [Header("Configurações de Tiro")]
    public GameObject bulletPrefab; // Arraste o arquivo da bala da pasta Project
    public Transform firePoint;     
    public float fireRate = 0.6f;   
    private float nextFireTime;

    void Update()
    {
        // Usando o botão direito do mouse (Fire2)
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
{
    // 1. Calculamos o vetor de direção (Ponta da arma - Centro do corpo)
    // Isso nos dá um vetor que aponta exatamente para onde a arma está
    Vector2 direcaoReal = (firePoint.position - transform.position).normalized;

    // 2. Criamos a bala
    GameObject bala = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

    // 3. Passamos essa direção exata para dentro do script da bala
    if (bala.TryGetComponent<Bullet>(out Bullet scriptBala))
    {
        scriptBala.ConfigurarDirecao(direcaoReal);
    }
}
}