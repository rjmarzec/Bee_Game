using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    public GameObject swordGuyPrefab;
    public GameObject redBulletPrefab;

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
        unitAlive = currentUnit != null;
    }

    private void OnMouseDown()
    {
        if(!unitAlive)
        {
            // Summon a sword_guy
            if (Input.GetMouseButtonDown(0))
            {
                unitAlive = true;
                currentUnit = Instantiate(swordGuyPrefab, rigidbody2d.position, Quaternion.identity);
            }
            // Summon a bow_guy
            if (Input.GetMouseButtonDown(1))
            {
                // Will do later
            }
        }
    }
}
