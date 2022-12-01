using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] List<GameObject> imagesToChange;
    [SerializeField] float timeDelay;
    [SerializeField] bool timeRunning;
    [SerializeField] bool started;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        timeDelay = 1;
        if (imagesToChange != null && imagesToChange.Count > 0)
        {
            foreach (GameObject g in imagesToChange)
            {
                g.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsStarted()
    {
        return started;
    }

    public void StartTimer()
    {
        timeRunning = true;
        started = true;
    }

    public void showPictures()
    {
        Debug.Log("Image index: " + index);

        if (index >= imagesToChange.Count)
        {
            imagesToChange[index - 1].SetActive(false);
            return;
        }

        //switch(index)
        //{
        //    case 0:
        //        imagesToChange[index].SetActive(true);
        //        break;
        //    case 1:
        //        imagesToChange[0].SetActive(false);
        //        imagesToChange[1].SetActive(true);
        //        break;
        //    default:
        //        break;
        //}

        if (index == 0)
        {
            imagesToChange[index].SetActive(true);
        }
        else if (index < imagesToChange.Count)
        {
            imagesToChange[index - 1].SetActive(false);
            imagesToChange[index].SetActive(true);
        }
        index++;
        timeRunning = true;

        //Might need to check for click later
        timeDelay = 5;
    }

    public bool CanSwitchPictures()
    {
        if (timeRunning)
        {
            if (timeDelay > 0)
            {
                timeDelay -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");

                timeDelay = 0;
                timeRunning = false;
                return true;
            }
        }
        return false;
    }
}
