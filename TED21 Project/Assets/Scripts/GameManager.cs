using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Delaring Variables
    public bool manStart = false;
    public static int publicScore = 0;

    public static int score = 0;
    public int maxRubbish = 20;
    public GameObject rubbish1;
    public GameObject rubbish2;
    public GameObject planet;


    private static int rubbish = 0;
    
    // Main function 
    public void gameRun()
    {
        // Loops for each piece of rubbish tha needs to be spawned
        for (int i = 0; i < maxRubbish - rubbish; i++)
        {
            // Checks if the amount of rubbish is b
            if (rubbish <= maxRubbish)
            {
                
                int RN = Random.Range(1, 3); // Gets random number 1 or 2
                GameObject spawning; // Delares a new 

                // Picks either bottle or paper depending on the number
                if (RN == 1)
                {
                    spawning = rubbish1; 
                }
                else
                {
                    spawning = rubbish2;
                }

                // Spawns the rubbish that was picked above and rotates it correctly
                Vector3 spawnPosition = Random.onUnitSphere * ((planet.transform.localScale.x / 2) 
                    + spawning.transform.localScale.y * 0.5f) + planet.transform.position;

                spawnObject(spawning, spawnPosition);

                // Adds one to the count of total rubbish
                rubbish += 1;
                
            }
        }
            
    }

    //Spawns a object at a location and gives it gravity and rubbish tag
    public void spawnObject(GameObject obj, Vector3 loc)
    {
        Quaternion spawnRotation = Quaternion.identity;
        GameObject spawnedObject = Instantiate(obj, loc, spawnRotation) as GameObject;
        spawnedObject.AddComponent<GravityBody>();
        spawnedObject.tag = "Rubbish";
    }

    // Removes one rubbish (called from other classes) 
    public static void removeRubbish()
    {
        rubbish -= 1;
    }


    // Runs every frame
    public void Update()
    {
        gameRun();
        publicScore = score;
    }
}
