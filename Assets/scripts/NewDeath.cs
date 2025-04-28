using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Vector2 respawnPosition; // where the player should go after dying

    private void Start()
    {
        respawnPosition = transform.position; // save starting position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        // Optional: reset health, animations, etc.
    }
}

