using UnityEngine;

public class TakeDamage : MonoBehaviour {

    private float damageInterval = 2f;
    private float currentDamageInterval;

    private void Update() {
        if(currentDamageInterval >= 0)
            currentDamageInterval -= Time.deltaTime;
    }

    public bool CanTakeDamage() {
        return (currentDamageInterval < 0);
    }

    public void EnemyTakeDamage(int damageAmount) {
        Health health = gameObject.GetComponent<Health>();

        if(gameObject.CompareTag("Hazard")) {
            health.currentHealth -= damageAmount;
            Debug.Log("health subtracting");
            currentDamageInterval = damageInterval;
            if (health.currentHealth <= 0)
                Destroy(gameObject);
        }
    }
}
