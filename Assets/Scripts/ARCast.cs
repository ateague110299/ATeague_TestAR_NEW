using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCast : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject objectRef;
    public List<GameObject> Planes;
    public ARPlaneManager ARPM;
    public static ARCast ARRC;
    public Animator myAnimator;
    public bool doorIsPlaced; 

    // Start is called before the first frame update
    void Start()
    {
        ARRC = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.transform.tag == "yes")
                    {
                        myAnimator.SetTrigger("Spin");
                    }

                    else if (hitObject.transform.tag == "no")
                    {
                        myAnimator.SetTrigger("Scale");
                    }

                    if (doorIsPlaced == false)
                    {
                        objectRef.transform.position = hitObject.point;
                        objectRef.gameObject.SetActive(true);
                        TurnOffAllPlanes();
                    }
                }
            }
        }
    }
    public void TurnOffAllPlanes()
    {
        doorIsPlaced = true; 
        foreach (var id in Planes)
        {
            id.gameObject.SetActive(false);
        }
    }
}
