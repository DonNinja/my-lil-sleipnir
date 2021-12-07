using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnyKey : MonoBehaviour
{
    // Detects if any key has been pressed.

    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
            SceneManager.LoadSceneAsync("Introduction");
        }
    }
}
