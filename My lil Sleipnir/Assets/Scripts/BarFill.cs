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
    int hygiene_count = 0;
    int comfort_count = 0;

    private void Awake() {
        hygiene_count = 0;
        comfort_count = 0;
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
                if (hygiene_count < 2) {
                    GameManager.instance.hygiene = targetProgress;
                    hygiene_count++;
                }
                else {
                    targetProgress -= newProgress;
                }
                break;
            case 2:
                if (comfort_count < 2) {
                    GameManager.instance.comfort = targetProgress;
                    comfort_count++;
                }
                else {
                    targetProgress -= newProgress;
                }
                break;
            default:
                Debug.LogError("WTF");
                break;
        }
        Debug.Log(hygiene_count);
        Debug.Log(comfort_count);
    }
    public void ResetProgress() {
        slider.value = 0;
        targetProgress = 0;
    }
}