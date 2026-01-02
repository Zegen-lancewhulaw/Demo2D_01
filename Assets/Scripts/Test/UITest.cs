using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITest : MonoBehaviour
{
    public Rect titleRect;
    public GUIContent titleContent;
    public GUIStyle titleStyle;

    public Rect btnRect0;
    public Rect btnRect1;
    public Rect btnRect2;

    public GUIStyle btnStyle;
    private void OnGUI()
    {
        GUI.Label(titleRect, titleContent, titleStyle);

        if(GUI.Button(btnRect0, "开始游戏", btnStyle))
        {
            SceneManager.LoadScene("MainGameScene");
        }
        GUI.Button(btnRect1, "设置", btnStyle);
        GUI.Button(btnRect2, "退出游戏", btnStyle);
    }
}
