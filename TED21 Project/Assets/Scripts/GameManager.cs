using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    // Delaring Varibles
    public static int publicScore = 0;

    public static int score = 0;
    public int maxRubbish = 20;
    public GameObject rubbish1;
    public GameObject rubbish2;
    public GameObject planet;
    public UIPollution uip;


    public static int rubbish = 0;
    
    // Runs every frame
    public void gameRun()
    {
        // Repeats for all rubbish that needs to be spawned in
        for (int i = 0; i < maxRubbish - rubbish; i++)
        {
            // checks if the rubbish is less than the allowed amount
            if (rubbish <= maxRubbish)
            {
                // Gets a random number to pick the type of rubbish
                int RN = Random.Range(1, 3);
                GameObject spawning;
                if (RN == 1)
                {
                    spawning = rubbish1;
                    
                }
                else
                {
                    spawning = rubbish2;
                    
                }
                // Creates locations for the spawing rubbish
                Vector3 spawnPosition = Random.onUnitSphere * ((planet.transform.localScale.x / 2) 
                    + spawning.transform.localScale.y * 0.5f) + planet.transform.position;
                //Spawns the rubbish
                spawnObject(spawning, spawnPosition);
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

    // Removes 1 from the rubbish total
    public void removeRubbish()
    {
        rubbish -= 1;
        // Does the UI update
        uip.removeP();
    }


    // Runs every frame
    public void Update()
    {
        gameRun();
        publicScore = score;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
