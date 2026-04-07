using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarraVidafinalBoss :MonoBehaviour 
{
   [SerializeField]
   private Slider slider;

     public int VidaMaxima{
        set{
               this.slider.maxValue = value;
        }

     }
    public int Vida {
    set{
         this.slider.value = value; 
         }

    }


}
