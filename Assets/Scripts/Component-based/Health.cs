using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }
}
