using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject Panel;
    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IAMissile"))
        {
            TakeDamage(20); // Puedes ajustar la cantidad de daño según tus necesidades
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Asegúrate de que la salud no sea negativa
        currentHealth = Mathf.Max(0, currentHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            // Reproduce un sonido cuando el jugador muere
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
                Panel.SetActive(true);
                Time.timeScale = 0f;
            }

            // Aquí puedes manejar la lógica de muerte del objeto si es necesario
            Debug.Log("El jugador ha muerto");
        }
    }

    void UpdateHealthUI()
    {
        // Actualiza la barra de vida si tienes una asignada
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }
}
