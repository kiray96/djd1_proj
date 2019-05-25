using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{

    /*[SerializeField]
    GameObject persianPrefab;

    [SerializeField]
    GameObject imortallPrefab;

    [SerializeField]
    GameObject wizardPrefab; */

    [SerializeField]
    GameObject Lose;



    public EnumArmyStates currentState;
    public int nTroops;

    [HideInInspector]
    public float speedModifier = 1;

    
    public float damagePenalty;

    [HideInInspector]
    public float defenseModifier;
    [HideInInspector]
    public float attackModifier;

    // How much mass is each soldier worth
    [SerializeField] protected float troopWeight;

    
    Animator anim;

    [HideInInspector]
    public float massModifier;

    [HideInInspector]
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

        if (nTroops <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        if (damage > defense * defenseModifier)
        {
            if (GetComponent<EnemyBehaviour>() != null)
            {

                GetComponent<EnemyBehaviour>().agressiveMod -= damagePenalty;

            }

            nTroops -= (int)damage;
        }

        //                GAMEOVER

        if (nTroops >= 0 && GameObject.FindGameObjectWithTag("Player"))
        {
            Lose.SetActive(true);
        }

    }
}
