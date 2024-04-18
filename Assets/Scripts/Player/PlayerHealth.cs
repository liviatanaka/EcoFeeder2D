using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    [SerializeField] private Material redFlashMat;
    private SpriteRenderer spriteRenderer;


    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;


    protected override void Awake() {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();

        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();

    }

    private void Start() {
        currentHealth = maxHealth;

        UpdateHealthSlider();
    }

    private void OnCollisionStay2D(Collision2D other) {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();

        if (enemy) {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.dano);
            TakeDamage(1, other.transform);
        }
    }

    public void HealPlayer() {
        if (currentHealth < maxHealth) {
            currentHealth += 1;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.coracao);
            UpdateHealthSlider();
        }
    }

    public void TakeDamage(int damageAmount, Transform hitTransform) {
        if (!canTakeDamage) { return; }

       
        knockback.GetKnockedBack(hitTransform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        CheckIfPlayerDeath();
    }

    private void CheckIfPlayerDeath() {
        if (currentHealth <= 0) {
            currentHealth = 0;
            canTakeDamage = false;
            spriteRenderer.material = redFlashMat;
            StartCoroutine(DeathRoutine());
            AudioManager.Instance.StopSFX();
            AudioManager.Instance.PlaySFX(AudioManager.Instance.morte);
            AudioManager.Instance.StopMusic();
            Debug.Log("Player Death");
        }
    }

    private IEnumerator DeathRoutine() {

        spriteRenderer.material = redFlashMat;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.material = redFlashMat;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.material = redFlashMat;
        yield return new WaitForSeconds(.3f);
        // disable player
        // gameObject.SetActive(false);
        SceneManager.LoadScene(5);


    }

    private IEnumerator DamageRecoveryRoutine() {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    private void UpdateHealthSlider() {
        if (healthSlider == null) {
            healthSlider = GameObject.Find("Health Slider").GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
