using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    private int lastScene;
    public void Setup(int score, int scene){
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

    public void cenaFases(){
        SceneManager.LoadScene("cenaFases");
    }
    
}
