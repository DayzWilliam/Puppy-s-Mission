using UnityEngine;

public class DamageBox : MonoBehaviour
{
    [Header("Configuração de Dano")]
    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("ta pelo menos dando trigger...?");

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                print("Damage Triggered");
            }
        }
    }
}
