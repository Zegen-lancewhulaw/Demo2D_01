using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneTest : MonoBehaviour
{

    public Rect audioToggleRect;
    public GUIContent audioToggleContent;

    public Rect modeOneRect;
    public Rect modeTwoRect;
    public Rect modeThreeRect;
    public GUIContent modeOneContent;
    public GUIContent modeTwoContent;
    public GUIContent modeThreeContent;

    public GUIStyle defaultToggleStyle;

    private bool _isSelected;
    private int _selectedIndex = 1;
    private void OnGUI()
    {
        _isSelected = GUI.Toggle(audioToggleRect, _isSelected, audioToggleContent, defaultToggleStyle);
        if (GUI.Toggle(modeOneRect, _selectedIndex == 1, modeOneContent, defaultToggleStyle))
        {
            _selectedIndex = 1;
        }
        if (GUI.Toggle(modeTwoRect, _selectedIndex == 2, modeTwoContent, defaultToggleStyle))
        {
            _selectedIndex = 2;
        }
        if (GUI.Toggle(modeThreeRect, _selectedIndex == 3, modeThreeContent, defaultToggleStyle))
        {
            _selectedIndex = 3;
        }
    }
}
