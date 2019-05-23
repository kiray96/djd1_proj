using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIdle : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        currFormation = EnumArmyStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControl)
        {

            if(!Input.anyKey)
            {
                ActivateFormation();
            }

        }
        
    }
}
