using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif

        //GameManager.instance.hunger -= Random.Range(0f, 2f);
        //GameManager.instance.hygiene -= Random.Range(0f, 5f);
        //GameManager.instance.comfort -= Random.Range(0f, 3f);

        //SceneManager.LoadSceneAsync("MenuFinal");
    }
}
