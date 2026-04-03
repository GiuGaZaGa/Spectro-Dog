using UnityEngine;

public class Biteinterface : MonoBehaviour
{
    
    public PlayerMeleeAttack playermelee;

    public void CallBiteMethod(){

        playermelee.EndAtack();

    }

}
