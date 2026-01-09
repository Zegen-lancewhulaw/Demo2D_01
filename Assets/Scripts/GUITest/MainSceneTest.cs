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

    public Rect backgroundRect;
    public Texture backgroundTex;

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
        // 绘制背景图
        GUI.DrawTexture(backgroundRect, backgroundTex);
        // 绘制标题
        GUI.Label(titleRect, titleContent, titleStyle);

        // 绘制开始游戏按钮
        if(GUI.Button(btnRect0, "开始游戏", btnStyle))
        {
            LoginPanelTest.WakeUp();
            this.gameObject.SetActive(false);
        }

        // 绘制设置按钮
        if(GUI.Button(btnRect1, "设置", btnStyle))
        {
            SettingPanelTest.WakeUp();
            this.gameObject.SetActive(false);
        }

        // 绘制退出游戏按钮
        GUI.Button(btnRect2, "退出游戏", btnStyle);
    }
}
