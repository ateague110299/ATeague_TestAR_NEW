using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlaneLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ARCast.ARRC.Planes.Add(gameObject);
    }

    // Update is called once per frame

}
