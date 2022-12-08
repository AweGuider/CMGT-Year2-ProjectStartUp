using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableText : MonoBehaviour
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var text = GetComponent<TextMeshProUGUI>();

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //int linkIndex = TMP_TextUtilites
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
