using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour {

    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject healthBarGO;
    Health health;
    HealthBar healthBar;
    TakeDamage takeDamage;

    private void Start() {
        takeDamage = gameObject.AddComponent<TakeDamage>();
        health = gameObject.GetComponent<Health>();
        healthBar = healthBarGO.GetComponent<HealthBar>();
    }
    //if the player collides with enemy weak spot and can damage enemy
    private void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.CompareTag("Hazard") && collision.gameObject.CompareTag("Player") && takeDamage.CanTakeDamage()) {
            takeDamage.EnemyTakeDamage(damageAmount);
            healthBar.SetHealth(health.currentHealth);
        }
            
        //if (gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Hazard"))
    }
}
