using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
        UnityEditor.EditorApplication.isPaused = true;
#endif

        GameManager.instance.EndGame();
    }
}
