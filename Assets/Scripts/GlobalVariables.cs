using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int leftHoneyCount;
    public static int rightHoneyCount;

    public static int leftSelectedUnit;
    public static int rightSelectedUnit;

    public Sprite p1WinSprite;
    public Sprite p2WinSprite;
    public Sprite pressEscapeSprite;

    // Start is called before the first frame update
    void Start()
    {
        leftHoneyCount = -1;
        rightHoneyCount = -1;
    }

    // Update is called once per frame
    void Update()
    { }

    public static void IncLeftHoneyCount()
    {
        leftHoneyCount++;
        if(leftHoneyCount > 10)
        {
            leftHoneyCount = 10;
        }
    }

    public static void IncRightHoneyCount()
    {
        rightHoneyCount++;
        if (rightHoneyCount > 10)
        {
            rightHoneyCount = 10;
        }
    }

    public static bool payLeftHoneyCount(int cost)
    {
        if(leftHoneyCount - cost >= 0)
        {
            leftHoneyCount -= cost;
            return true;
        }
        return false;
    }

    public static bool payRightHoneyCount(int cost)
    {
        if (rightHoneyCount - cost >= 0)
        {
            rightHoneyCount -= cost;
            return true;
        }
        return false;
    }
}
