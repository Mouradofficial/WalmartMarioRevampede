using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
       player = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal") ,player.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
        player.velocity = new Vector2(player.velocity.x, 5);
        }
    }
}
