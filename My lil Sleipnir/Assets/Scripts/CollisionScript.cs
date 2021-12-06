using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        // TODO: Crash horse
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
