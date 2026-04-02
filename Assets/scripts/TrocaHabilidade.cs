using UnityEngine;

public class ManagerHabilidade : MonoBehaviour
{

    public GameObject melee;
    public GameObject shooter;
    private bool corpo = true;
    static public bool temShoot = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2")&& temShoot){

            ChangeHabilidade();


        }
    }
    void ChangeHabilidade(){

        corpo = !corpo;

        melee.SetActive(corpo);
        shooter.SetActive(!corpo);

    }
}