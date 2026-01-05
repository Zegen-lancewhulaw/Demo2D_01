using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SettingPanelTest : MonoBehaviour
{
    public Rect backgroundRect;
    public Texture backgroundTex;

    public static SettingPanelTest instance;
    public static void WakeUp()
    {
        instance.gameObject.SetActive(true);
    }

    public Rect closeRect;
    public GUIStyle closeStyle;

    public Rect UIBoxRect;

    public Rect audioToggleRect;
    public GUIContent audioToggleContent;

    public Rect audioVolumnLabelRect;
    public GUIContent audioVolumnLabelContent;
    public GUIStyle audioVolumnLabelStyle;

    public Rect audioVolumnSliderRect;
    

    public Rect modeOneToggleRect;
    public GUIContent modeOneToggleContent;

    public Rect modeTwoToggleRect;
    public GUIContent modeTwoToggleContent;

    public Rect modeThreeToggleRect;
    public GUIContent modeThreeToggleContent;

    public GUIStyle defaultToggleStyle;

    private bool _isAudioEnable;
    private int _modeIndex = 1;
    private float _currentAudioVolumn = 100f;
    private readonly float maxAudioVolumn = 100f;
    private readonly float minAudioVolumn = 0f;


    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
    }
    private void OnGUI()
    {
        // 绘制背景图
        GUI.DrawTexture(backgroundRect, backgroundTex);

        // 绘制UI框
        GUI.Box(UIBoxRect, string.Empty);

        // 关闭键
        if (GUI.Button(closeRect, string.Empty, closeStyle))
        {
            MainSceneTest.WakeUp();
            this.gameObject.SetActive(false);
        }

        // 复选框：开启声音
        _isAudioEnable = GUI.Toggle(audioToggleRect, _isAudioEnable, audioToggleContent, defaultToggleStyle);
        // 横向拖动条：音量
        GUI.Label(audioVolumnLabelRect, audioVolumnLabelContent, audioVolumnLabelStyle);
        _currentAudioVolumn = GUI.HorizontalSlider(audioVolumnSliderRect, _currentAudioVolumn, minAudioVolumn, maxAudioVolumn);


        // 单选框：模式一、二、三
        if(GUI.Toggle(modeOneToggleRect, _modeIndex == 1, modeOneToggleContent, defaultToggleStyle))
        {
            _modeIndex = 1;
        }
        if (GUI.Toggle(modeTwoToggleRect, _modeIndex == 2, modeTwoToggleContent, defaultToggleStyle))
        {
            _modeIndex = 2;
        }
        if (GUI.Toggle(modeThreeToggleRect, _modeIndex == 3, modeThreeToggleContent, defaultToggleStyle))
        {
            _modeIndex = 3;
        }
    }
}
