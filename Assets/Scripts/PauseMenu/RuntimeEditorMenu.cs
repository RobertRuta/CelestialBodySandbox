using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeEditorMenu : MonoBehaviour
{
    Toggle toggle;
    ColorBlock togCol;
    Color defaultCol;
    Color defaultHighlightCol;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();                
        togCol = toggle.colors;
        defaultCol = togCol.normalColor;
        defaultHighlightCol = togCol.highlightedColor;
        togCol.normalColor = new Color(0.2f, 0.85f, 0.3f, 1f);
        togCol.highlightedColor = new Color(0.2f, 0.9f, 0.3f, 1f);
    }

    // Update is called once per frame
    public void ColourToggleOnClick()
    {
        if (toggle.isOn) 
        {
            togCol.normalColor = new Color(0.2f, 0.85f, 0.3f, 1f);
            togCol.highlightedColor = new Color(0.2f, 0.9f, 0.3f, 1f);
        }
        else
        {
            togCol.normalColor = defaultCol;
            togCol.highlightedColor = defaultHighlightCol;
        }

        toggle.colors = togCol;
    }
}
