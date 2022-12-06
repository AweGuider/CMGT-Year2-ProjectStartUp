using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;

    void Start()
    {
        if (transitionTime == 0)
        {
            transitionTime = 1f;
        }
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
