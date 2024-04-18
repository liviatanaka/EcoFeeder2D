using UnityEngine;
using UnityEngine.SceneManagement;



public class HouseLevel : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    
    //start method
    private void Start()
    {
        // Checa se a fase foi completada
        if (PlayerPrefs.GetInt("Level" + sceneIndex + "Complete", 0) == 1)
        {
            // Cria uma nova instância do material para este objeto
            Material newMat = new Material(GetComponent<Renderer>().material);
            newMat.color = Color.green; // Muda a cor para verde
            GetComponent<Renderer>().material = newMat; // Aplica o material novo
        }
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MarkLevelComplete(sceneIndex);
            GetComponent<Renderer>().material.color = Color.green;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void MarkLevelComplete(int level)
    {
        PlayerPrefs.SetInt("Level" + level + "Complete", 1);
        PlayerPrefs.Save();
        
        
    }

    private void update ()
    {

    }
}
