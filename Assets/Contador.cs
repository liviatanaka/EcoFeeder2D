using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contador : Singleton<Contador>
{
    public int currentLevelIndex; // Variável pública para definir o índice da fase atual no editor
    private List<GameObject> animals = new List<GameObject>();

    public int contador = -1;

    void Start()
    {
        Transform animalsParent = GameObject.FindGameObjectWithTag("Animal").transform;
        foreach (Transform child in animalsParent)
        {
            animals.Add(child.gameObject);
        }

        contador = animals.Count;
    }

    public void SubtractContador()
    {
        contador--;
        Debug.Log("Contador: " + contador);
    }


    void Update()
    {
        
        if (contador == 0)
        {
            Debug.Log("Level Complete!");
            MarkLevelComplete();
            SceneManager.LoadScene("Scenes/cenaFases");  // Nome da cena que lista todas as fases

            if (currentLevelIndex == 2){
                if (PlayerPrefs.GetInt("Level" + 0 + "Complete", 0) == 1)
                {
                    if (PlayerPrefs.GetInt("Level" + 1 + "Complete", 0) == 1)
                    {
                        SceneManager.LoadScene("Scenes/Vitoria");
                    }
                }
            }
            if (currentLevelIndex == 1){
                if (PlayerPrefs.GetInt("Level" + 0 + "Complete", 0) == 1)
                {
                    if (PlayerPrefs.GetInt("Level" + 2 + "Complete", 0) == 1)
                    {
                        SceneManager.LoadScene("Scenes/Vitoria");
                    }
                }
            }

            if (currentLevelIndex == 0){
                if (PlayerPrefs.GetInt("Level" + 1 + "Complete", 0) == 1)
                {
                    if (PlayerPrefs.GetInt("Level" + 2 + "Complete", 0) == 1)
                    {
                        SceneManager.LoadScene("Scenes/Vitoria");
                    }
                }
            }

        }
    }


    void MarkLevelComplete()
    {
        PlayerPrefs.SetInt("Level" + currentLevelIndex + "Complete", 1);
        PlayerPrefs.Save();
        Debug.Log("Level " + currentLevelIndex + " marked as complete.");
    }
}
