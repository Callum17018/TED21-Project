using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //Changes the scene
    public void startGame()
    {
        
        SceneManager.LoadScene(1);
        GameManager.score = 0;
        GameManager.rubbish = 0;
        UIPollution.pollution = 0;

        
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
