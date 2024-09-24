// Contributors: John Nguyen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float speed = 5.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Get input from player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Set the animations for the player's character model
        anim.SetFloat("Vertical", moveVertical);
        anim.SetFloat("Horizontal", moveHorizontal);

        // Create a new Vector3 for the movement direction based on input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // MOve the player character by applying movement vector with speed + deltaTime
        MovePlayer(movement);
    }

    // Separate method to allow player to move using Rigidbody
    void MovePlayer(Vector3 movement)
    {
        Vector3 newPosition = rb.position + movement * speed * Time.deltaTime;

        rb.MovePosition(newPosition);
    }
}
