using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;

    private void Awake()
    {
        if (buttons == null)
        {
            buttons = new List<Button>();
        }
        if (buttons.Count == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {

            }
            foreach (Transform child in transform)
            {
                //Debug.Log(child.name);
                Button b = child.GetComponent<Button>();
                buttons.Add(b);
                b.interactable = false;
            }
            buttons[0].interactable = true;

        }
    }
}
