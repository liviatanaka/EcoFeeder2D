using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour, IWeapon
{

    private PlayerController playerController;
    public void Attack(){
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
             Vector2 throwDirection = playerController.GetLastDirection();

            // Adicione uma força para lançar o milho nessa direção
            GetComponent<Rigidbody2D>().AddForce(throwDirection.normalized * 10f, ForceMode2D.Impulse);

            // Destrua o milho após um tempo
            Destroy(gameObject, 2f);   
         

            // Escolha a animação correta com base na direção do arremesso
            
 
        }
        
    }

   


}
