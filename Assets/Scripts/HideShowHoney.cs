using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowHoney : MonoBehaviour
{
    public bool isLeft;
    public int number;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLeft)
        {
            if(number <= GlobalVariables.leftHoneyCount)
            {
                sr.enabled = true;
            }
            else
            {
                sr.enabled = false;
            }
        }
        else
        {
            if(number <= GlobalVariables.rightHoneyCount)
            {
                sr.enabled = true;
            }
            else
            {
                sr.enabled = false;
            }
        }
    }
}
