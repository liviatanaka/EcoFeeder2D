using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public int currentLevelIndex; // Variável pública para definir o índice da fase atual no editor
    private List<GameObject> animals = new List<GameObject>();

    void Start()
    {
        LoadAllAnimals();
    }

    void Update()
    {
        if (animals.Count == 0)
        {
            MarkLevelComplete();
            SceneManager.LoadScene("SceneFases");  // Nome da cena que lista todas as fases
        }
    }

    void LoadAllAnimals()
    {
        GameObject[] loadedAnimals = Resources.LoadAll<GameObject>("Animals");
        foreach (GameObject animal in loadedAnimals)
        {
            GameObject instance = Instantiate(animal);
            animals.Add(instance);
        }
    }

    public void RemoveAnimal(GameObject animal)
    {
        if (animals.Contains(animal))
        {
            animals.Remove(animal);
            Destroy(animal);
        }
    }

    void MarkLevelComplete()
    {
        PlayerPrefs.SetInt("Level" + currentLevelIndex + "Complete", 1);
        PlayerPrefs.Save();
        Debug.Log("Level " + currentLevelIndex + " marked as complete.");
    }
}
