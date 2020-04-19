using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowP2Win : MonoBehaviour
{
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        sr.enabled = true;
    }
}
