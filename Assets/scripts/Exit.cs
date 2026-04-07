using UnityEngine;
using UnityEditor;

public class Exit : MonoBehaviour
{
   public void OnMouseDown()
    {
        // For final standalone builds
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        // For the Unity Editor play mode
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
    }
}
