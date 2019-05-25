using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    float minDistanceToCharge;
    [SerializeField]
    float minDistanceToBrace;
   


    float distanceToPlayer;

    float agressiveMod;

    float choiceWeight;

    float chanceToBrace;
    float chanceToCharge;

    Formation[] possibleStates;


    GameObject playerArmy;
    private void Awake()
    {
        // Gets all components whpo inherit from the Formation class
        possibleStates = GetComponents<Formation>();

    }
    // Start is called before the first frame update
    void Start()
    {
        playerArmy = GetComponentInParent<Player>().gameObject;

        // Tell them they shouldn't care about input
        foreach (Formation p in possibleStates)
            p.SetControllable(false);


    }

    // Update is called once per frame
    void Update()
    {
        // Get distance to player
        distanceToPlayer = (playerArmy.transform.position - gameObject.transform.position).magnitude;



        //choiceWeight = Random.Range();

        // Enemy charges earlier if more agressive
        minDistanceToCharge *= agressiveMod;

        // Enemy braces sooner if less agressive
        minDistanceToBrace *= 1 + agressiveMod;

        float deltaC = distanceToPlayer - minDistanceToCharge;
        float deltaB = distanceToPlayer - minDistanceToBrace;

        if (distanceToPlayer > minDistanceToCharge)
        {
            // very big chance to Charge
            chanceToCharge /= ;
            
        }
        else
            chanceToCharge = 0;



        if (distanceToPlayer < minDistanceToBrace)
        {
            // very big chance to Brace
            chanceToBrace /= 0.5f;
        }
        else
            chanceToBrace = 0;


        if (chanceToBrace > chanceToCharge)
        {

            GetComponent<FBrace>().ActivateFormation();

        }
        else if (chanceToCharge < chanceToBrace)
        {

            GetComponent<FCharge>().ActivateFormation();

        }



    }
}
