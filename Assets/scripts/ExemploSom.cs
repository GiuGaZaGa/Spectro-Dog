using UnityEngine;

public class ExemploSom : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Opcional: obter o componente automaticamente se ele estiver no mesmo objeto
        // audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Toca o som apenas quando colidir
        audioSource.Play();
    }
}