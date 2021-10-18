using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject arrow;

    float fireRate;
    float nextFire;
    Coroutine fireCoroutine; 

    // Start is called before the first frame update
    void Start()
    {
        //fireRate = 2f;
        //nextFire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIfTimeToFire();
    }

    public IEnumerator ContinueFire()
    {
        while (true)
        {
            if (Time.time > nextFire)
            {
                Instantiate(arrow, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
            yield return null;
        }
    }


    /*void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fireRate = 3f;
            nextFire = Time.time;
            if (fireCoroutine == null)
                {
                    
                    fireCoroutine = StartCoroutine(ContinueFire());
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fireCoroutine != null)
            {
                StopCoroutine(fireCoroutine);
                fireCoroutine = null;
            }
        }
    }
}
