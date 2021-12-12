using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroductionScript : MonoBehaviour
{
    // Start is called before the first frame update

    public void changeToStables()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }
}
