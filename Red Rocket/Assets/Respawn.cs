using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.CompareTag("Enemy"))
        {
            // log action
            Debug.Log("Player died");
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        transform.position = spawnPoint.position;
        Debug.Log("Player respawned to: " + spawnPoint.position);
    }
}
