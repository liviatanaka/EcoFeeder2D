using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private string specialAlimentTag;

    private int currentHealth;
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;

    private void Awake() {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start() {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Projectile alimento = other.gameObject.GetComponent<Projectile>();


        if (alimento) {
            if (other.tag == specialAlimentTag) {
                TakeDamage(3, other.transform);
            } else {
                TakeDamage(1, other.transform);
            }

        }

    }


    public void TakeDamage(int damageAmount, Transform hitTransform) {
        if (!canTakeDamage) { return; }

       
        knockback.GetKnockedBack(hitTransform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        CheckIfAnimalDeath();
    }
    

    private void CheckIfAnimalDeath() {
        if (currentHealth <= 0) {
            currentHealth = 0;
            Debug.Log("Animal Death");
        }
    }

    
    private IEnumerator DamageRecoveryRoutine() {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

}