using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtnTest : MonoBehaviour
{
    public Rect backBtnRect;
    public GUIStyle backBtnStyle;
    private void OnGUI()
    {
        if(GUI.Button(backBtnRect, "·µ»Ø", backBtnStyle))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

}
