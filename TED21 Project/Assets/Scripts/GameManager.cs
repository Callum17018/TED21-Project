using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool manStart = false;

    public int maxRubbish = 20;
    public GameObject rubbish1;
    public GameObject rubbish2;
    public GameObject planet;


    private static int rubbish = 0;
    

    public void gameRun()
    {
        for (int i = 0; i < maxRubbish - rubbish; i++)
        {
            //Debug.Log("Game Tick Run");
            if (rubbish <= maxRubbish)
            {
                
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

                Vector3 spawnPosition = Random.onUnitSphere * ((planet.transform.localScale.x / 2) 
                    + spawning.transform.localScale.y * 0.5f) + planet.transform.position;

                spawnObject(spawning, spawnPosition);
                rubbish += 1;
                
            }
        }
            
    }


    public void spawnObject(GameObject obj, Vector3 loc)
    {
        Quaternion spawnRotation = Quaternion.identity;
        GameObject spawnedObject = Instantiate(obj, loc, spawnRotation) as GameObject;
        spawnedObject.AddComponent<GravityBody>();
    }

    public void Update()
    {
        if (manStart)
        {
            gameRun();
            manStart = false;
        }
    }
}
