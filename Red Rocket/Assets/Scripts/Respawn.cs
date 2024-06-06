using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;
    public AudioSource audioSource;
    public AudioClip deathSound;

    private bool isRespawning = false;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.CompareTag("Enemy"))
        {
            // log action
            Debug.Log("Player died");
            isRespawning = true; // Set the flag to true when the player dies
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Play death sound only if respawning due to death
        if (isRespawning && audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
            isRespawning = false; // Reset the flag after playing the sound
        }

        transform.position = spawnPoint.position;
        Debug.Log("Player respawned to: " + spawnPoint.position);
    }
}