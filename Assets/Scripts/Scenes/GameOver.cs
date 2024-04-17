using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    private string lastScene;
    public void Setup(int score, string scene){
        gameObject.SetActive(true);
        lastScene = scene;
        pointsText.text = "Você alimentou "+ score.ToString() + " animais!";
    }
    public void Restart(){
        SceneManager.LoadScene(lastScene);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
}
