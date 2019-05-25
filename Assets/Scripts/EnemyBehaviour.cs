using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    

    [SerializeField]
    float minDistanceToCharge;
    [SerializeField]
    float minDistanceToBrace;
    [SerializeField]
    float chanceToDoNothing = 0.20f;

    float distanceToPlayer;

    float agressiveMod;

    float chanceToBrace;
    float chanceToCharge;
    


    Formation[] possibleStates;

    float[] chanceList;


    GameObject playerArmy;

    Attack atkScript;

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

        chanceList = new float[possibleStates.Length + 1];
           
    }

    // Update is called once per frame
    void Update()
    {

        Mathf.Clamp(chanceToCharge, 0, 1);
        Mathf.Clamp(chanceToBrace, 0, 1);
        Mathf.Clamp(agressiveMod, 0, 1);

        
        // Get distance to player
        distanceToPlayer = (playerArmy.transform.position - gameObject.transform.position).magnitude;

        Formation next = CalculateNextState();
        if (next != null)
            next.ActivateFormation();


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

    Formation CalculateNextState()
    {
        float sum = 0.0f;
        chanceList[0] = chanceToDoNothing;

        // REMINDER:
        // chanceList has 1 more value than possibleStates, this is the chance 
        // that the enemy will not change his state.

        for (int i = 0; i < possibleStates.Length; i++)
        {
            if (possibleStates[i] as FCharge != null) chanceList[i + 1] = chanceToCharge;
            if (possibleStates[i] as FBrace != null) chanceList[i + 1] = chanceToBrace;
            // more chances for more formation spossible
        }


        foreach (float f in chanceList)
        {
            sum += f;
        }

        float r = Random.Range(0, sum);


        if (sum < chanceList[0])
        {
            return null;
        }

        sum -= chanceList[0];

        for (int i = 1; i < chanceList.Length - 1; i++)
        {
            if (sum < chanceList[i])
            {
                return possibleStates[i - 1];

            }

            sum -= chanceList[i];
        }

        return null;

    }
}
