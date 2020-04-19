using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowUnit : MonoBehaviour
{
    public bool isLeft;
    public int cost;
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
            if(GlobalVariables.leftHoneyCount < cost)
            {
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }
        }
        else
        {
            if(GlobalVariables.rightHoneyCount < cost)
            {
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }
        }

        if(isLeft)
        {
            if(cost == GlobalVariables.leftSelectedUnit)
            {
                transform.localScale = new Vector3(4, 4, 0);
            }
            else
            {
                transform.localScale = new Vector3(2.5f, 2.5f, 0);
            }
        }
        else
        {
            if(cost == GlobalVariables.rightSelectedUnit)
            {
                transform.localScale = new Vector3(4, 4, 0);
            }
            else
            {
                transform.localScale = new Vector3(2.5f, 2.5f, 0);
            }
        }
    }
}
