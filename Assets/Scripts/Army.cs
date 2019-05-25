using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{

    [SerializeField]
    GameObject persianPrefab;

    [SerializeField]
    GameObject imortallPrefab;

    [SerializeField]
    GameObject wizardPrefab;


    public EnumArmyStates currentState;
    public int nTroops;
    public float speedModifier = 1;

    public float defenseModifier;
    public float attackModifier;

    // How much mass is each soldier worth
    [SerializeField] protected float troopWeight;

    
    Animator anim;


    public float massModifier;
    public float defense;

    private void Update()
    {
        GetComponent<Rigidbody2D>().mass *= massModifier;
        anim = GetComponent<Animator>();

        /*if (persianPrefab && nTroops <= 0)
        {
            Destroy(gameObject);
            anim.SetBool("Dead", true);
        }

        if (imortallPrefab && nTroops <= 0)
        {
            Destroy(gameObject);
            anim.SetBool("Dead", true);
        }

        if (wizardPrefab && nTroops <= 0)
        {
            Destroy(gameObject);
            anim.SetBool("Dead", true);
        }*/

        if (nTroops <= 0) Destroy(gameObject);
    }


    public void TakeDamage(float damage)
    {
        if (damage > defense * defenseModifier)
        {
            nTroops -= (int)damage;

        }

    }


}
