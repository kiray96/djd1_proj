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
    float chanceToDoNothing = 0.20f;


    Formation[] possibleStates;

    float[] chanceList;


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
        {
            p.SetControllable(false);

        }

        chanceList = new float[possibleStates.Length];
           
    }

    // Update is called once per frame
    void Update()
    {

        Mathf.Clamp(chanceToCharge, 0, 1);
        Mathf.Clamp(chanceToBrace, 0, 1);

        
        // Get distance to player
        distanceToPlayer = (playerArmy.transform.position - gameObject.transform.position).magnitude;



 

    }

    void CalculateChanceToCharge()
    {

        // Enemy charges earlier if more agressive
        minDistanceToCharge *= agressiveMod;

        if (distanceToPlayer > minDistanceToCharge)
        {
            // very big chance to Charge
            chanceToCharge /= (1 / distanceToPlayer);
            Debug.Log("1/distance to player = " + 1 / distanceToPlayer);

        }
        else
            chanceToCharge *= (1 / distanceToPlayer);

    }

    void CalculateChanceToBrace()
    {
        // Enemy braces sooner if less agressive
        minDistanceToBrace *= 1 + agressiveMod;

        if (distanceToPlayer < minDistanceToBrace)
        {
            // very big chance to Brace
            chanceToBrace *= (1 / distanceToPlayer);
        }
        else
            chanceToBrace /= (1 / distanceToPlayer);

    }


}
