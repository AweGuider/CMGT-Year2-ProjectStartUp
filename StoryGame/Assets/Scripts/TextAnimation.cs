using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] float letterPause;
    // Start is called before the first frame update
    void Start()
    {
        letterPause = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TypeSentence(string sentence, TextMeshProUGUI output)
    {
        string[] array = sentence.Split(' ');
        output.text = array[0];
        Debug.Log(string.Format("Sentence: {0}, amount of words: {1}", sentence, array.Length));

        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            output.text += " " + array[i];
        }
    }
}
