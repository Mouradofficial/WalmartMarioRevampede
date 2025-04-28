using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SwingingHammer : MonoBehaviour
{
    public float startForce = 5f; // Initial push to make the hammer swing
    public float pushForce = 10f; // Force applied to the player
    public AudioSource hitSound; // Optional sound effect

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(startForce, ForceMode2D.Impulse); // Initial push to start swinging
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                Vector2 pushDirection = collision.transform.position - transform.position;
                pushDirection.Normalize();

                playerRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

                if (hitSound != null)
                {
                    hitSound.Play();
                }
            }
        }
    }
}


