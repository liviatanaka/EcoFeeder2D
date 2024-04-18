using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHealthTutorial : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private string specialAlimentTag;
    // private AudioClip audioClip;
    private int currentHealth;
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;

    private void Awake() {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        // audioClip = AudioManager.Instance.getClip(gameObject.tag);
    }

    private void Start() {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Projectile alimento = other.gameObject.GetComponent<Projectile>();

        // play the sound
        // AudioManager.Instance.PlaySFX(audioClip);
        if (alimento) {
            if (other.tag == specialAlimentTag) {
                TakeDamage(3, other.transform);
            }
            // destroy the projectile
            Destroy(other.gameObject);
        }

    }


    public void TakeDamage(int damageAmount, Transform hitTransform) {
        if (!canTakeDamage) { 
            
            return; }

       
        knockback.GetKnockedBack(hitTransform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        CheckIfAnimalDeath();
        // AudioManager.Instance.PlaySFX(audioClip);
    }
    

    private void CheckIfAnimalDeath() {
        if (currentHealth <= 0) {
            // audioSource.Play();
            currentHealth = 0;
            Contador.Instance.SubtractContador();
            //wait before destroy

            Destroy(gameObject);

        }
    }

    
    private IEnumerator DamageRecoveryRoutine() {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
         // play the sound
        // AudioManager.Instance.PlaySFX(audioClip);
    }

}