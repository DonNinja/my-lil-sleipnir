using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarFill : MonoBehaviour
{
    // Start is called before the first frame update

    private Slider slider;

    public float fillSpeed = 0.5f;
    public int type;

    private float targetProgress = 0;
    private void Awake() {
        slider = gameObject.GetComponent<Slider>();

        switch (type) {
            case 0:
                slider.value = GameManager.instance.hunger;
                break;
            case 1:
                slider.value = GameManager.instance.hygiene;
                break;
            case 2:
                slider.value = GameManager.instance.comfort;
                break;
            default:
                Debug.LogError("WTF");
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        if (slider.value < targetProgress) {
            slider.value += fillSpeed * Time.deltaTime;
        }
    }

    public void IncrementProgress(float newProgress) {
        targetProgress = slider.value + newProgress;
        switch (type) {
            case 0:
                GameManager.instance.hunger = targetProgress;
                break;
            case 1:
                GameManager.instance.hygiene = targetProgress;
                break;
            case 2:
                GameManager.instance.comfort = targetProgress;
                break;
            default:
                Debug.LogError("WTF");
                break;
        }
    }
    public void ResetProgress() {
        slider.value = 0;
        targetProgress = 0;
    }
}