using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    int honey;

    // Amount of damage the enemy will inflict when it runs into the player
    public int damageStrength;

    // Reference to a running coroutine
    Coroutine damageCoroutine;

    private void OnEnable()
    {
        ResetCharacter();
    }

    public override void ResetCharacter()
    {
        honey = startingHoney;
    }
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        // Continuously inflict damage until the loop breaks
        while (true)
        {
            if (interval > 0)
            {
                // Wait a specified amount of seconds and inflict more damage
                yield return new WaitForSeconds(interval);
            }
            else
            {
                // Interval = 0; inflict one-time damage and exit loop
                break;
            }
        }
    }

    // Called by the Unity engine whenever the current enemy object's collider2D makes contact with another object's Collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // See if enemy has collided with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get a reference to the colliding player object
            CanBePickedUp player = collision.gameObject.GetComponent<CanBePickedUp>();

            // If coroutine is not currently executing
            if (damageCoroutine == null)
            {
                // Start the coroutine to inflict damage to the player every 1 second
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }

    // Called by the Unity engine whenevr the current enemy object stops touching another object's Collider2D
    private void OnCollisionExit2D(Collision2D collision)
    {
        // See if enemy has just stopped colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // If coroutine is currently executing
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}
