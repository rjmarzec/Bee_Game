using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Unit
{
    // Update is called once per frame
    override public void Update()
    {
        // Heart is a strange type of unit, so need to overwrite the
        //      Update() function to "end" the game.
        if (health <= 0)
        {
            Destroy(gameObject);
            // Stop the game after a heart is destroyed
            Time.timeScale = 0;
        }
    }
}