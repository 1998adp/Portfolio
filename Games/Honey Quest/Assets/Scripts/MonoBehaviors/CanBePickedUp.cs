using UnityEngine;
using System.Collections;

public class CanBePickedUp : Character
{
    public HealthBar healthBarPrefab;
    public Honey honey;
    HealthBar healthBar;
    public AudioClip deathClip;


    private void OnEnable()
    {
        ResetCharacter();
    }
    public void Start()
    {
        honey.value = startingHoney;

        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }
    // Called when player's collider touches an "Is Trigger" collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Retrieve the game object that the player collided with, and check the tag
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            // Grab a reference to the Item (scriptable object) inside the Consumable class and assign it to hitObject
            // Note: at this point it is a coin, but later may be other types of CanBePickedUp objects
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            // Check for null to make sure it was successfully retrieved, and avoid potential errors
            if (hitObject != null)
            {
                // debugging
                print("it: " + hitObject.objectName);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.HONEY:
                        AdjustHoney();
                        break;

                    default:
                        break;
                }

                // Hide the game object in the scene to give the illusion of picking up
                collision.gameObject.SetActive(false);
            }
        }
    }

    public void AdjustHoney()
    {
        if (honey.value < 4)
        {
            honey.value = honey.value + 1;
            print("Adjusted honey amount by: 1. New value: " + honey);
        }
        
    }
    public override void ResetCharacter()
    {
        // Start the player off with the starting hit point value
        honey.value = startingHoney;

        // Get a copy of the health bar prefab and store a reference to it
        healthBar = Instantiate(healthBarPrefab);

        // Set the healthBar's character property to this character so it can retrieve the maxHitPoints
        healthBar.character = this;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        // Continuously inflict damage until the loop breaks
        while (true)
        {
            // Inflict damage
            honey.value = honey.value - damage;

            // Player is dead; kill off game object and exit loop
            if (honey.value < 0)
            {
                KillCharacter();
                break;
            }

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
    public virtual void KillCharacter()
    {
        // Play sound and destroy the current game object and remove it from the scene
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
        Destroy(gameObject, 2);
    }
}
