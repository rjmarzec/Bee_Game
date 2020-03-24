using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    public GameObject unit1Prefab;
    public GameObject unit2Prefab;
    public GameObject unit3Prefab;
    public GameObject unit4Prefab;
    public GameObject unit5Prefab;
    public GameObject unit6Prefab;
    public KeyCode selectionBoxKey;
    public bool isLeftSideBox;

    Rigidbody2D rigidbody2d;
    GameObject currentUnit;
    bool unitAlive;

    List<KeyCode> unitKeys;
    List<GameObject> unitPrefabs;

    GameObject unitType;
    bool unitSelected;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        unitAlive = false;

        unitPrefabs = new List<GameObject> { unit1Prefab, unit2Prefab, unit3Prefab, unit4Prefab, unit5Prefab, unit6Prefab };

        if (isLeftSideBox)
            unitKeys = new List<KeyCode> { KeyCode.Q, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.Z, KeyCode.X };
        else
            unitKeys = new List<KeyCode> { KeyCode.LeftBracket, KeyCode.RightBracket, KeyCode.Semicolon, KeyCode.Quote, KeyCode.Period, KeyCode.Slash };
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

        checkInput();

    }

    private void checkInput()
    {
        if(!unitSelected)
        {
            for(int i = 0; i < 6; i ++)
            {
                if(unitSelected = Input.GetKeyDown(unitKeys[i]))
                {
                    unitType = unitPrefabs[i];
                    break;
                }
            }
        }
        else if(unitSelected)
        {
            // Check all the related keys to see 
            for(int i = 0; i < 6; i ++)
            {
                if(Input.GetKeyDown(unitKeys[i]))
                {
                    unitSelected = false;
                    if(unitKeys[i] == selectionBoxKey && (currentUnit == null || currentUnit.GetComponent<Unit>().health <= 0))
                    {
                        // Summon the unit of the selected key
                        currentUnit = Instantiate(unitType, rigidbody2d.position, Quaternion.identity);

                        // If the unit is on the right, change it's direction
                        if (!isLeftSideBox)
                        {
                            currentUnit.GetComponent<Unit>().direction = -1;
                        }

                        // If a unit was just summoned, hide the selection box
                        if (currentUnit != null)
                        {
                            unitAlive = true;
                            gameObject.GetComponent<Renderer>().enabled = false;
                        }

                        // Don't summon any more units
                        break;
                    }

                }

            }
        }
    }
}

/*
    //The old unit spawning method, preserved in case things break down

    private void OnMouseDown()
        {
            if(!unitAlive)
            {
                // Summon a ladybug (tank)
                // Right clicking on a Macbook trackpad doesn't work for some reason, so
                //      this chunky if statement lets you ctrl + left click instead.
                if (Input.GetMouseButtonDown(1) || (Input.GetKey("left ctrl") && Input.GetMouseButtonDown(0)))
                {
                    currentUnit = Instantiate(unit1Prefab, rigidbody2d.position, Quaternion.identity);
                }
                // Summon a bee (ranged dmg)
                else if (Input.GetMouseButtonDown(0))
                {
                    currentUnit = Instantiate(unit2Prefab, rigidbody2d.position, Quaternion.identity);
                }

                // If a unit was just summoned, hide the selection box
                if(currentUnit != null)
                {
                    unitAlive = true;
                    gameObject.GetComponent<Renderer>().enabled = false;
                }
            }
        }
 */
