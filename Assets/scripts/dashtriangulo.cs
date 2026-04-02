using UnityEngine;

public class dashtriangulo : MonoBehaviour
{

    private Rigidbody2D fisicaPlayer;
    public float forcaDash = 50f;

    void Start()
    {
        fisicaPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 

        if(Input.GetButtonDown("Dash"))
        {
            Dash();
        
        }
       
    }
    
    void Dash()
    {
       
        fisicaPlayer.AddForce(Vector2.right * forcaDash, ForceMode2D.Impulse);       
        Debug.Log("oioi");

    }
}
