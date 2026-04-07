using UnityEngine;

public class MusicaContinua : MonoBehaviour
{
    private static MusicaContinua instancia;

    void Awake()
    {
        // Padrão Singleton: Garante que só exista UMA trilha sonora tocando
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Impede que o objeto seja deletado
        }
        else
        {
            Destroy(gameObject); // Se já existir uma música, deleta a duplicata
        }
    }
}
