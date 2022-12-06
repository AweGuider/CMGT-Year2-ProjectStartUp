using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] List<GameObject> imagesToChange;
    [SerializeField] float timeDelay;
    [SerializeField] bool done;

    void Start()
    {
        index = 0;
        if (imagesToChange != null && imagesToChange.Count > 0)
        {
            foreach (GameObject g in imagesToChange)
            {
                g.SetActive(false);
            }
        }
    }

    public bool IsDone()
    {
        return done;
    }

    public void SetDone(bool b)
    {
        done = b;
    }

    public void showTimeIsUp()
    {
        gameObject.SetActive(true);
        imagesToChange[0].SetActive(true);

        //if (index >= imagesToChange.Count)
        //{
        //    imagesToChange[index - 1].SetActive(false);
        //    done = true;
        //    index = 0;
        //    return;
        //}

        //if (index == 0)
        //{
        //    imagesToChange[index].SetActive(true);
        //}
        //else if (index < imagesToChange.Count)
        //{
        //    imagesToChange[index - 1].SetActive(false);
        //    imagesToChange[index].SetActive(true);
        //}
        //index++;
    }


    public void showGameEnd()
    {
        imagesToChange[2].SetActive(true);

    }
}