using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginPanelTest : MonoBehaviour
{
    public static LoginPanelTest instance;
    public static void WakeUp()
    {
        if(instance != null)
        {
            instance.gameObject.SetActive(true);
        }
    }

    public Rect backgroundRect;
    public Texture backgroundTex;

    public Rect UIBoxRect;

    public Rect closeRect;
    public GUIStyle closeStyle;

    public Rect userNameLabelRect;
    public GUIContent userNameLabelContent;
    public GUIStyle userNameLabelStyle;

    public Rect userNameFieldRect;
    public GUIStyle userNameFieldStyle;

    public Rect passwordLabelRect;
    public GUIContent passwordLabelContent;
    public GUIStyle passwordLabelStyle;

    public Rect passwordFieldRect;
    public GUIStyle passwordFieldStyle;

    public Rect affirmBtnRect;
    public GUIContent affirmBtnContent;
    public GUIStyle affirmBtnStyle;

    private string _userName = string.Empty;
    private string _password = string.Empty;

    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
    }

    private void OnGUI()
    {
        // »æÖÆ±³¾°Í¼
        GUI.DrawTexture(backgroundRect, backgroundTex);

        // »æÖÆUI¿ò
        GUI.Box(UIBoxRect, string.Empty);

        // ¹Ø±Õ¼ü
        if (GUI.Button(closeRect, string.Empty, closeStyle))
        {
            MainSceneTest.WakeUp();
            this.gameObject.SetActive(false);
        }

        GUI.Label(userNameLabelRect, userNameLabelContent, userNameLabelStyle);
        _userName = GUI.TextField(userNameFieldRect, _userName, userNameFieldStyle);

        GUI.Label(passwordLabelRect, passwordLabelContent, passwordLabelStyle);
        _password = GUI.PasswordField(passwordFieldRect, _password, '*', passwordFieldStyle);

        if (GUI.Button(affirmBtnRect, affirmBtnContent, affirmBtnStyle) || Input.GetKeyDown(KeyCode.Return)){
            if (_userName == "admin" && _password == "8888")
            {
                SceneManager.LoadScene("MainGameScene");
            }
        }
    }
}
