using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    private Transform respawnPoint;
    [SerializeField] private Player playerHealth;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private HealthBar healthBar;

    private void Start() {
        GameObject rp = GameObject.FindWithTag("Respawn Point");
        respawnPoint = rp.transform;
    }

    void Update() {
        PlayerHealthZero();
    }

    /// <summary>
    /// If the Player touches a trigger collider that is tagged "Respawn
    /// Trigger", this sets the Player's position to the Respawn Point.
    /// </summary>
    /// <param name="other">The Player's collider.</param>
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Respawn Trigger")) {
            Debug.Log("this tag finding is true");
            gameObject.transform.position = respawnPoint.position;
            FlipToFaceRight();
            RestoreHealth();
        }
    }

    /// <summary>
    /// If the Player's current health is 0, set the Player's
    /// position to the Respawn Point.
    /// </summary>
    void PlayerHealthZero() {
        if (playerHealth.currentHealth == 0) {
            transform.position = respawnPoint.position;
            FlipToFaceRight();
            RestoreHealth();
        }
    }

    void FlipToFaceRight() {
        if(playerController.isFacingRight == false) {
            GetComponent<SpriteRenderer>().flipX = false;
            playerController.isFacingRight = true;
        }
    }

    void RestoreHealth() {
        playerHealth.currentHealth = playerHealth.maxHealth;
        healthBar.SetHealth(playerHealth.currentHealth);
    }
}
