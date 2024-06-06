using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.CompareTag("Enemy"))
        {
            // log action
            Debug.Log("Player died");
            animator.SetBool("IsDying", true);
            RespawnPlayer();
            animator.SetBool("IsDying", false);
        }
    }

    void RespawnPlayer()
    {
        transform.position = spawnPoint.position;
        Debug.Log("Player respawned to: " + spawnPoint.position);
    }
}