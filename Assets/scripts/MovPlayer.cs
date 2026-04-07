using System.Collections;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public Rigidbody2D fisicaPlayer;

    [Header("Configurações de Movimento")]
    [SerializeField] private float velocidadePlayer = 8f;
    [SerializeField] private float alturaPuloPlayer = 12f;

    [Header("Configurações de Pulo")]
    [SerializeField] private LayerMask layerDoChao;
    [SerializeField] private float distanciaRaycast = 0.2f;

    [Header("Configurações de Dash")]
    public static bool temDash = false; // Mudei para true para teste, altere conforme seu progresso
    [SerializeField] private float forcaDash = 20f;
    [SerializeField] private float tempoDash = 0.2f;
    [SerializeField] private float cooldownDash = 1f;
    [SerializeField] public Animator animator;

    private float inputHorizontal;
    private bool podePuloDuplo;
    private bool estaNoChao;
    private bool olhandoDireita = true;
    
    private bool estaNoDash;
    private bool podeDarDash = true;
    private float gravidadeOriginal;

    public static bool derrotouBoss = false;
    private bool porta;
    private GameObject novaPorta;

    void Start()
    {
        fisicaPlayer = GetComponent<Rigidbody2D>();
        gravidadeOriginal = fisicaPlayer.gravityScale;
        novaPorta = GameObject.Find("novaPorta");
    }

    void Update()
    {
        // Se estiver no meio de um dash, não aceita outros inputs de movimento
        if (estaNoDash) return;

        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal < 0 && olhandoDireita) Flip();
        else if (inputHorizontal > 0 && !olhandoDireita) Flip();
        if(inputHorizontal != 0){
            animator.SetBool("isWalk", true);
        }else{
            animator.SetBool("isWalk", false);
        }

        estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaRaycast, layerDoChao);

        if (Input.GetButtonDown("Jump"))
        {
            if (estaNoChao)
            {
                ExecutarPulo();
                podePuloDuplo = true;
            }
            else if (podePuloDuplo)
            {
                ExecutarPulo();
                podePuloDuplo = false;
            }
        }

        // Lógica de Dash - Verifica se apertou o botão (ex: Left Shift ou customizado)
        // Certifique-se de configurar "Dash" nas Input Settings da Unity
        if (Input.GetButtonDown("Dash") && temDash && podeDarDash)
        {
            StartCoroutine(ExecutarDash());
        }
    }

    void FixedUpdate()
    {
        if (estaNoDash) return;

        fisicaPlayer.linearVelocity = new Vector2(inputHorizontal * velocidadePlayer, fisicaPlayer.linearVelocity.y);
    }

    private IEnumerator ExecutarDash()
    {
        podeDarDash = false;
        estaNoDash = true;

        // Tira a gravidade para o dash ser reto no ar
        fisicaPlayer.gravityScale = 0;

        // Define a direção baseada no Flip do personagem
        float direcao = olhandoDireita ? 1 : -1;
        
        // Aplica a velocidade de Dash
        fisicaPlayer.linearVelocity = new Vector2(direcao * forcaDash, 0);

        // Espera o tempo de duração do "impulso"
        yield return new WaitForSeconds(tempoDash);

        // Restaura o estado normal
        fisicaPlayer.gravityScale = gravidadeOriginal;
        estaNoDash = false;

        // Espera o cooldown para poder usar de novo
        yield return new WaitForSeconds(cooldownDash);
        podeDarDash = true;
    }

    void ExecutarPulo()
    {
        fisicaPlayer.linearVelocity = new Vector2(fisicaPlayer.linearVelocity.x, alturaPuloPlayer);
    }

    void Flip()
    {
        olhandoDireita = !olhandoDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distanciaRaycast);
    }
    private void novaPosicao()
    {
        if(porta = true)
        {
            fisicaPlayer.transform.position = new Vector2(novaPorta.transform.position.x, novaPorta.transform.position.y);
        }
    }
}