using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CollisionLogic : MonoBehaviour
{
    public GameObject door;
    public GameObject lookingIN;
    public GameObject lookingOUT;
    public GameObject Back;
    public GameObject DefaultLayerChildren;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
            foreach(Transform obj in DefaultLayerChildren.transform)
            {
                if (gameObject.transform.position.z < door.transform.position.z)
                {
                    obj.gameObject.layer = 0;
                    lookingIN.gameObject.SetActive(false);
                    lookingOUT.gameObject.SetActive(true);
                }
                else
                {
                    obj.gameObject.layer = 7;
                    lookingIN.gameObject.SetActive(true);
                    lookingOUT.gameObject.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
