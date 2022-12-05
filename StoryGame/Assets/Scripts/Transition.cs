using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;
    // Start is called before the first frame update
    void Start()
    {
        if (transitionTime == 0)
        {
            transitionTime = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTransition(string path)
    {
        StartCoroutine(LoadTransition(path));
    }

    IEnumerator LoadTransition(string path)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(path);
    }
}
