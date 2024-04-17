using UnityEngine;
using UnityEngine.SceneManagement;



public class HouseLevel : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MarkLevelComplete(sceneIndex);
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void MarkLevelComplete(int level)
    {
        PlayerPrefs.SetInt("Level" + level + "Complete", 1);
        PlayerPrefs.Save();
    }
}
