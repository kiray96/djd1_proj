using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base control for each "army" on in the game-
/// \
/// Hold information like number of troops (hp), modifiers 
/// speed, mass and attack power.
/// </summary>
public class Army : MonoBehaviour
{

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
    
    Animator anim;

    [HideInInspector]
    public float massModifier;

    [HideInInspector]
    public float defense;

    private void Update()
    {
        GetComponent<Rigidbody2D>().mass *= massModifier;
        anim = GetComponent<Animator>();

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
                // Enemies will get less agressive after being hurt, 
                GetComponent<EnemyBehaviour>().agressiveMod -= damagePenalty;

            }
        
            nTroops -= (int)damage;
            GetComponent<Followers>().UpdateFollowers(nTroops);
        }

        //                GAMEOVER

        if (nTroops >= 0 && GameObject.FindGameObjectWithTag("Player"))
        {
            Lose.SetActive(true);
        }

    }
}
