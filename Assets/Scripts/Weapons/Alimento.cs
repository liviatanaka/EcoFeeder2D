using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alimento : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject alimentoPrefab;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");

    public void Attack()
    {
    // Encontra o objeto com a tag "Player"
    Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    // Obtem a posição do mouse na tela e converte para uma posição no mundo
    Vector3 mousePosition = Input.mousePosition;
    mousePosition.z = Camera.main.nearClipPlane; // Importante para manter o z consistente
    Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

    // Calcula a direção a partir da posição do jogador até a posição do mouse
    Vector3 direction = (worldMousePosition - playerTransform.position).normalized;

    // Cria a flecha na posição do jogador
    GameObject newAlimento = Instantiate(alimentoPrefab, playerTransform.position, Quaternion.identity);

    Destroy(newAlimento, 2f);
    // Ajusta a rotação da flecha para apontar na direção do mouse
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    newAlimento.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
