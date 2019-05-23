using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{

    public EnumArmyStates currentState;
    public int nTroops;
    public float speedModifier = 1;

    public float defenseModifier;
    public float attackModifier;

    // How much mass is each soldier worth
    [SerializeField] protected float troopWeight;


    public float massModifier;
    public float defense;

    private void Update()
    {
        GetComponent<Rigidbody2D>().mass *= massModifier;
        if (nTroops <= 0) Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (damage > defense * defenseModifier)
        {
            nTroops -= (int)damage * (int)defenseModifier;

        }


    }


}
