using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to reload the scene

public class DeathZone : MonoBehaviour
{
    public AudioSource audioSource; // Assign in Unity Inspector
    public AudioClip deathSound; // Assign the death sound effect

    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDead) // Check if player enters the death zone
        {
            isDead = true;
            audioSource.PlayOneShot(deathSound); // Play the sound
            StartCoroutine(ReloadSceneAfterSound()); // Wait for the sound to finish
        }
    }

    IEnumerator ReloadSceneAfterSound()
    {
        yield return new WaitForSeconds(deathSound.length); // Wait for sound to finish
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }
}
