using System.Collections;
using UnityEngine;

public class MissileLoop : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;
    public float respawnDelay = 1f;

    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        StartCoroutine(MoveMissile());
    }

    private IEnumerator MoveMissile()
    {
        while (true)
        {
            yield return MoveToPoint(pointB.position);

            // Simulate "destroy"
            spriteRenderer.enabled = false;
            if (col != null) col.enabled = false;

            yield return new WaitForSeconds(respawnDelay);

            // Reset and "respawn"
            transform.position = pointA.position;
            spriteRenderer.enabled = true;
            if (col != null) col.enabled = true;
        }
    }

    private IEnumerator MoveToPoint(Vector2 target)
    {
        Vector2 start = transform.position;
        float distance = Vector2.Distance(start, target);
        float duration = distance / speed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector2.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
