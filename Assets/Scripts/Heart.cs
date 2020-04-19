using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Unit
{
    public GameObject winnerText;
    public GameObject escapeText;

    // Update is called once per frame
    override public void Update()
    {
        // Heart is a strange type of unit, so need to overwrite the
        //      Update() function to "end" the game.
        if (health <= 0)
        {
            Destroy(gameObject);

            GameObject text1 = Instantiate(winnerText, new Vector3(0, 0, -20), Quaternion.identity);
            GameObject text2 = Instantiate(escapeText, new Vector3(0, -2, -20), Quaternion.identity);

            // Stop the game after a heart is destroyed
            Time.timeScale = 0;
        }
    }

    // Override the sound playing of the heart. It's as simple as that.
    public override void Damage(int damageTaken)
    {
        health -= damageTaken;
    }
}
