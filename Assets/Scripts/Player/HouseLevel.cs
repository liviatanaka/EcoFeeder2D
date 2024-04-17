using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar o namespace para gerenciamento de cenas

public class HouseLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);  // Para debug, mostrar quem entrou no trigger

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered, loading scene...");  // Confirmação de que o jogador entrou
            SceneManager.LoadScene(0);
        }
    }

}
