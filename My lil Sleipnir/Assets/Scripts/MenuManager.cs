using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public void changeToRunner()
    {
        audioSource.Play();
        SceneManager.LoadSceneAsync("RunningBreki");
    }
}
