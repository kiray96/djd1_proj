using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackObject : MonoBehaviour
{


    private Rigidbody2D rb;
   
    public float dmg, lifeTime, reachSpd;

    
    public bool isProjectile;

    public Vector3 origin;

    float timeBeforeDestruct = 2f;

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
        var vel = rb.velocity;

        

        if(!isProjectile)
        {


            if (dist < lifeTime)
            {
 
                rb.velocity = new Vector3(reachSpd, 0, 0);
                Debug.Log(dist);
                dist ++;
               
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
}
