using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedBarsSidebar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BarPanel;
    public GameObject Sidepanel;
    public void ShowNeedBars()
    {
        Sidepanel.gameObject.SetActive(false);
        BarPanel.gameObject.SetActive(true);
    }

    public void HideNeedBars()
    {
        BarPanel.gameObject.SetActive(false);
        Sidepanel.gameObject.SetActive(true);
    }

}
