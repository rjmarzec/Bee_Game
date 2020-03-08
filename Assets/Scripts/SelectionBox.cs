using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    public GameObject swordGuyPrefab;
    public GameObject bowGuyPrefab;

    Rigidbody2D rigidbody2d;
    GameObject currentUnit;
    bool unitAlive;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        unitAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the summoned unit is still alive
        unitAlive = currentUnit != null;

        // Show the selection box if a unit is not currently summoned on it
        if(!unitAlive)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if(!unitAlive)
        {
            // Summon a bow_guy
            // Right clicking on a Macbook trackpad doesn't work for some reason, so
            //      this chunky if statement lets you ctrl + left click instead.
            if (Input.GetMouseButtonDown(1) || (Input.GetKey("left ctrl") && Input.GetMouseButtonDown(0)))
            {
                currentUnit = Instantiate(bowGuyPrefab, rigidbody2d.position, Quaternion.identity);
            }
            // Summon a sword_guy
            else if (Input.GetMouseButtonDown(0))
            {
                currentUnit = Instantiate(swordGuyPrefab, rigidbody2d.position, Quaternion.identity);
            }

            // If a unit was just summoned, hide the selection box
            if(currentUnit != null)
            {
                unitAlive = true;
                gameObject.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
