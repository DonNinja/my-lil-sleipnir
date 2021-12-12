using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStables : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeToStables()
    {
        SceneManager.LoadSceneAsync("Menu-Breki");
    }
}