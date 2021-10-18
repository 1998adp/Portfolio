using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // public variables appear as properties in Unity's inspector window
    public float movementSpeed;

    // holds 2D points; used to represent a character's location in 2D space, or where it's moving to
    Vector2 movement = new Vector2();

    // holds reference to the animator component in the game object
    Animator animator;

    // used to refer to the animation parameter that will be updated
    // use a variable to refer to this instead of hard-coding this name each time it's needed
    string animationState = "AnimationState";

    // reference to the character's Rigidbody2D component
    Rigidbody2D rb2D;

    // enumered constants to correspond to the values assigned to the animations
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleEast = 5
    }

    // Start is called before the first frame update
    void Start()
    {
        // get references to game object component so it doesn't have to be grabbed each time needed
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the animation state machine
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void UpdateState()
    {
        // determine if GetAxisRaw returns -1, 0 or 1, and which axis
        // and change the state of the specified animation parameter accordingly
        // The GetComponents change the box collider based on the direction the player is moving/idle
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
            GetComponent<BoxCollider2D>().size = new Vector2(3.294323f, 1.494487f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0.003480554f, 0.002237201f);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
            GetComponent<BoxCollider2D>().size = new Vector2(3.361209f, 1.453729f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.001835823f, -0.001113623f);
        }
        else if (movement.y > 0)
        {
           animator.SetInteger(animationState, (int)CharStates.walkNorth);
            GetComponent<BoxCollider2D>().size = new Vector2(1.28039f, 2.447579f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.0002440214f, 0.2434907f);
        } 
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
            GetComponent<BoxCollider2D>().size = new Vector2(1.284264f, 2.403002f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0.003210306f, 0.2689624f);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idleEast);
            GetComponent<BoxCollider2D>().size = new Vector2(1.738273f, 2.578454f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.003750801f, 0.3566881f);
        }
            

    }

    private void MoveCharacter()
    {
        // get user input
        // GetAxisRaw parameter allow us to specify which axis we're interested in
        // Returns 1 = right key or "d" (up key or "w")
        //        -1 = left key or "a" (down key or "s")
        //         0 = no key pressed
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // keeps player moving at the same rate of speed, no matter which direction they are moving in
        movement.Normalize();

        // set velocity of RigidBody2D and move it
        rb2D.velocity = movement * movementSpeed;
    }

}
