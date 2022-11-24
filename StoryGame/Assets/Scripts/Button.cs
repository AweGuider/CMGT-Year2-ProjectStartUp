using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Data data;

    // Start is called before the first frame update
    void Start()
    {
        if (data == null)
        {
            data = FindObjectOfType<Data>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();

        //FingerTouch();
    }

    private void MouseClick()
    {
        //Left button clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(string.Format("Obj name: " + hit.collider.gameObject.name));

                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("CCCCCCCCCCCCCCCCCCCCC");

                }
                // the object identified by hit.transform was clicked
                // do whatever you want
            }
        }
    }

    private void FingerTouch()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray))
                {
                    Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAA");
                    // Create a particle if hit
                    //Instantiate(particle, transform.position, transform.rotation);
                }
            }
        }
    }
}
