using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostThisCatReaction : MonoBehaviour
{
    public GameObject yesButton;
    public GameObject noButton;
    public Animation spin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            spin.Play();
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            gameObject.transform.localScale += new Vector3(1, 0, 1);
            yesButton.gameObject.SetActive(false);
        }
    }
}
