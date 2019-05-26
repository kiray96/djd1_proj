using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{

    [SerializeField]
    GameObject persianPrefab;

    [SerializeField]
    GameObject imortallPrefab;

    [SerializeField]
    GameObject witchPrefab;

    [SerializeField]
    GameObject Lose;

    public Text healthText;

    [SerializeField]
    public int TroopsTxt;

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

        if (nTroops <= 0)
        {
            Destroy(gameObject);
        }

        healthText.text = "" + TroopsTxt;
    }


    public void TakeDamage(float damage)
    {
        if (damage > defense * defenseModifier)
        {
            nTroops -= (int)damage;
            TroopsTxt -= (int)damage;
        }

        //                GAMEOVER

        if (nTroops >= 0 && GameObject.FindGameObjectWithTag("Player"))
        {
            Lose.SetActive(true);
        }

    }
}
