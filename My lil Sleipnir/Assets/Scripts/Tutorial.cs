using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{   
    public GameObject button1;
    public GameObject button2; 
    public GameObject button3;
    public void func_button1()
    {
        button1.SetActive(false);
        button2.SetActive(true);
    }
    public void func_button2()
    {
        button2.SetActive(false);
        button3.SetActive(true);
    }
    public void func_button3()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
