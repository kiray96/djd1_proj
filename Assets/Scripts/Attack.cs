using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    // In time you will know the tragic extent of my failings

    [SerializeField] bool playerControlled;
    [SerializeField] bool rangedAttack;
    [SerializeField] GameObject attackPrefab;

    [SerializeField] float damage;
    [SerializeField] float reach;
    [SerializeField] float reachSpeed;

    [SerializeField] float attackCooldown;

    [SerializeField] float timeBeforeDestruct;
    float currCooldown;
    Army armyScript;

    // Start is called before the first frame update
    void Start()
    {
        armyScript = GetComponent<Army>();
        currCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {

        currCooldown += Time.deltaTime;

        if(Input.GetAxis("Fire1") > 0 && currCooldown >= attackCooldown && playerControlled)
        {
            GameObject yeet = Instantiate(attackPrefab, transform.position, transform.rotation);

            var b = yeet.GetComponentInChildren<AttackObject>();
            b.dmg = damage * armyScript.attackModifier;
            b.lifeTime = reach;
            b.reachSpd = reachSpeed;
            b.isProjectile = rangedAttack;
            b.origin = transform.position;
            b.timeBeforeDestruct = this.timeBeforeDestruct;
            currCooldown = 0;

            for(float i = 0; i<500; i += i *Time.deltaTime)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

        }

        
    }
}
