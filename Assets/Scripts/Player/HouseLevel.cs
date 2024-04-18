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
            if (sceneIndex == 0){
                SceneManager.LoadScene("Scenes/fase1v2 1");
                Debug.Log("Level 1");
            } else if (sceneIndex == 1) {
                SceneManager.LoadScene("Scenes/fase2-fernando");
                Debug.Log("Level 2");
            } else if (sceneIndex == 2){
                SceneManager.LoadScene("Scenes/fase3E");
                Debug.Log("Level 3");
            }
            else {
                SceneManager.LoadScene(sceneIndex);
                Debug.Log("Level " + sceneIndex);
            }
            
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
