using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int healingAmount = 40;
    public float healingCooldown = 30f;
    private float currentHealingCooldown = 0f;
    public GameObject Panel;
    public Slider healthSlider;
    public GameObject deactivateButtons;
    public TextMeshProUGUI cooldownText;
    public AudioSource healAudioSource; // Asigna el Audio Source de curaci�n en el Inspector
    public List<AudioClip> healSounds;
    public AudioClip deathSound; // Asigna el Audio Clip de muerte en el Inspector
    public float deathVolume = 1.0f;

    private bool isDead = false; // Nueva variable para controlar si el jugador est� muerto

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void Update()
    {
        // Actualiza el temporizador de curaci�n
        if (currentHealingCooldown > 0f)
        {
            currentHealingCooldown -= Time.deltaTime;
            UpdateCooldownText();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("IAMissile"))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        if (!isDead) // Evita da�o adicional si ya est� muerto
        {
            currentHealth -= damage;
            currentHealth = Mathf.Max(0, currentHealth);
            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                HandleDeath();
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void HandleDeath()
    {
        isDead = true; // Marca al jugador como muerto
        healAudioSource.Stop(); // Det�n la reproducci�n del sonido de curaci�n

        // Reproduce el sonido de muerte usando AudioSource.PlayClipAtPoint con volumen ajustado
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, deathVolume);
        }

        // Resto del c�digo HandleDeath()
        deactivateButtons.SetActive(false);
        Panel.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego

        Debug.Log("El jugador ha muerto");
    }



    void UpdateCooldownText()
    {
        if (cooldownText != null)
        {
            cooldownText.text = Mathf.Ceil(currentHealingCooldown) + "s";
        }
    }

    public void Heal()
    {
        if (!isDead && currentHealth > 0 && currentHealingCooldown <= 0f)
        {
            // Reproduce el sonido de curaci�n solo si no est� en curso y el jugador no est� muerto
            if (!healAudioSource.isPlaying)
            {
                // Reproduce un sonido de curaci�n al azar desde una lista
                if (healSounds.Count > 0)
                {
                    AudioClip selectedHealSound = healSounds[Random.Range(0, healSounds.Count)];
                    healAudioSource.clip = selectedHealSound;
                }

                healAudioSource.Play();
            }

            // Aumenta la salud y reinicia el temporizador
            currentHealth += healingAmount;

            // Limita la salud al m�ximo de 120
            currentHealth = Mathf.Clamp(currentHealth, 0, 120);

            UpdateHealthUI();
            currentHealingCooldown = healingCooldown;
            UpdateCooldownText();
        }
        else if (currentHealth <= 0)
        {
            Debug.Log("El jugador est� muerto. No se puede curar.");
        }
        else
        {
            Debug.Log("Espera " + Mathf.Ceil(currentHealingCooldown) + " segundos antes de poder curarte nuevamente.");
        }
    }
}
