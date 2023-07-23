using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    //Coin count
    public int coincounter;

    public TextMeshProUGUI coinsCounter;

    // Start is called before the first frame update
    void Start()
    {
        //gets the Rigidbody Component from the player
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        coinsCounter.text = coincounter.ToString();

        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }
    //Update that handles Physics (every 0.01)
    private void FixedUpdate()
    {
        //adds a velocity on our rigidbody
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
            coincounter++;
        Destroy(collision.gameObject);
    }
}
