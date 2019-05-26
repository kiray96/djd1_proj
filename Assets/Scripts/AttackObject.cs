using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackObject : MonoBehaviour
{


    private Rigidbody2D rb;

    public float dmg, lifeTime, reachSpd, timeBeforeDestruct;

    
    public bool isProjectile;

    public Vector3 origin;
    public GameObject creator;
    

    float dist = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       // AttackStats = GetComponentInParent<Attack>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(!isProjectile)
        {

            dist ++;

            if (dist < lifeTime)
            {

               rb.velocity = transform.right * reachSpd;
                //Debug.Log(dist); 
               
            }
            else if (dist >= lifeTime)
                timeBeforeDestruct --;

            if (timeBeforeDestruct <= 0)
            {
                Destroy(gameObject);
                dist = 0;
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("god strike me down");
        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<Army>().TakeDamage(dmg);

           Debug.Log(tag);
            Destroy(this);
        }

    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<Army>().TakeDamage(dmg);
            
            Destroy(this.gameObject);
        }
    }



}
