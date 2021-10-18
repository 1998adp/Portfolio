using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{

   public float moveSpeed = 8f;

    Rigidbody2D rb;

    MovementController target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // This allows the arrows to seek the player through finding the movement controller
        target = GameObject.FindObjectOfType<MovementController>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        // After a set amount of time if the arrow does not hit the player the arrow is destoryed
        Destroy(gameObject, 3f);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
            SceneManager.LoadScene("TestScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
