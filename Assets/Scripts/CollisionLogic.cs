using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CollisionLogic : MonoBehaviour
{
    public GameObject lookingIN;
    public GameObject lookingOUT;
    public List<Transform> objectsToIgnoreCollisionLogic;
    public GameObject ObjectHolder;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            Transform[] allChildren = ObjectHolder.GetComponentsInChildren<Transform>();
            var direction = other.transform.position - transform.position;
            foreach (var obj in allChildren){
                if (!objectsToIgnoreCollisionLogic.Contains(obj)){
                    if (Vector3.Dot(other.transform.forward, direction) < 0){
                        obj.gameObject.layer = 8;
                        lookingIN.gameObject.SetActive(false);
                        lookingOUT.gameObject.SetActive(true);
                    } else {
                        obj.gameObject.layer = 7;
                        lookingIN.gameObject.SetActive(true);
                        lookingOUT.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
