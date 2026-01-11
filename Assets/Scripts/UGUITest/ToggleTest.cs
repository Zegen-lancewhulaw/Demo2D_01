using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTest : MonoBehaviour
{
    Toggle toggle;
    public GameObject tank;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((x) => {
            if(tank  != null)
            {
                if (x)
                {
                    tank.GetComponent<FireController>().FireAudioEnable = true;
                }
                else
                {
                    tank.GetComponent<FireController>().FireAudioEnable = false;
                }
            }
        });
    }
}
