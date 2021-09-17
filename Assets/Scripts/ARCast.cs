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
                    objectRef.transform.position = hitObject.point;
                    TurnOffAllPlanes();
                }
            }
        }
    }
    public void TurnOffAllPlanes()
    {
        ARRC.enabled = false;

        foreach (var id in Planes)
        {
            id.gameObject.SetActive(false);
        }
    }
}
