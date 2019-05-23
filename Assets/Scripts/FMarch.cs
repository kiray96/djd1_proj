using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMarch : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        currFormation = EnumArmyStates.March;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl)
        {

            if(Input.GetAxis("Horizontal") != 0)
            {
                ActivateFormation();
            }

        }        
    }
}
