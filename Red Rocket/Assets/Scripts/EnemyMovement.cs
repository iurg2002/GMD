using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float horizontalRange = 5f;
    public float verticalRange = 5f;

    private Vector3 startPosition;
    private float horizontalOffset;
    private float verticalOffset;

    void Start()
    {
        startPosition = transform.position;

        // Calculate offsets based on starting positions
        horizontalOffset = startPosition.x;
        verticalOffset = startPosition.y;
    }

    void Update()
    {
        // If speed is zero, do not move
        if (speed <= 0)
        {
            return;
        }

        float time = Time.time * speed;

        // Calculate new positions with checks to avoid NaN values
        float newX = startPosition.x;
        float newY = startPosition.y;

        if (horizontalRange > 0)
        {
            newX = horizontalOffset + Mathf.PingPong(time, horizontalRange) - (horizontalRange / 2);
        }

        if (verticalRange > 0)
        {
            newY = verticalOffset + Mathf.PingPong(time, verticalRange) - (verticalRange / 2);
        }

        // Update the position
        transform.position = new Vector3(newX, newY, startPosition.z);
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(horizontalOffset - (horizontalRange / 2), startPosition.y, startPosition.z), new Vector3(horizontalOffset + (horizontalRange / 2), startPosition.y, startPosition.z));
            Gizmos.DrawLine(new Vector3(startPosition.x, verticalOffset - (verticalRange / 2), startPosition.z), new Vector3(startPosition.x, verticalOffset + (verticalRange / 2), startPosition.z));
        }
    }
}
