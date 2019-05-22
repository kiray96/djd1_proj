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
    float currCooldown;

    // Start is called before the first frame update
    void Start()
    {
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
            b.dmg = damage;
            b.lifeTime = reach;
            b.reachSpd = reachSpeed;
            b.isProjectile = rangedAttack;
            b.origin = transform.position;

            currCooldown = 0;

        }

        
    }
}
