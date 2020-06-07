using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPollution : MonoBehaviour
{
    // Defines Varibles
    public static double pollution = 0;
    public double increase = 1;
    public Text scoreText;
    private IEnumerator coroutine;
    public GameObject endUI;

    void Start()
    {
        // Waits to start a routine
        coroutine = WaitAndPrint(1.0f);
        StartCoroutine(coroutine);

    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            // Counts up from 0 to 100 every 1 second
            yield return new WaitForSeconds(waitTime);
            pollution += increase;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pollution >= 100)
        {
            pollution = 100;
            // Calls the end of the game
            endUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        // Updates the UI for pollution
        scoreText.text = ("POLLUTION: " + pollution + "%");
    }
    public void removeP()
    {
        pollution -= 1;
        if (pollution > 100)
        {
            pollution = 100;

        }
    }
}
