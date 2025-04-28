using UnityEngine;

public class soundEffects : MonoBehaviour
{
    private static bool musicAlreadyPlaying = false;

    void Awake()
    {
        if (!musicAlreadyPlaying)
        {
            GetComponent<AudioSource>().Play();
            musicAlreadyPlaying = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

