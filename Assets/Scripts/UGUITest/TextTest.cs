using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text t  = GetComponent<Text>();
        t.text = "込込込込��";
        t.resizeTextForBestFit = true;
        (this.transform as RectTransform).sizeDelta = new Vector2(300, 100);
        t.fontStyle = FontStyle.Bold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
