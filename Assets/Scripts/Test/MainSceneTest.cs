using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneTest : MonoBehaviour
{
    public static MainSceneTest instance;
    public static void WakeUp()
    {
        if(instance != null)
        {
            instance.gameObject.SetActive(true);
        }
    }

    public Rect titleRect;
    public GUIContent titleContent;
    public GUIStyle titleStyle;

    public Rect btnRect0;
    public Rect btnRect1;
    public Rect btnRect2;

    public GUIStyle btnStyle;

    private void Awake()
    {
        instance = this;
    }

    private void OnGUI()
    {
        GUI.Label(titleRect, titleContent, titleStyle);

        if(GUI.Button(btnRect0, "开始游戏", btnStyle))
        {
            SceneManager.LoadScene("MainGameScene");
        }
        if(GUI.Button(btnRect1, "设置", btnStyle))
        {
            SettingPanelTest.WakeUp();
            this.gameObject.SetActive(false);
        }
        GUI.Button(btnRect2, "退出游戏", btnStyle);
    }
}
