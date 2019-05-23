using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBrace : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        currFormation = EnumArmyStates.Brace;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl)
        {

            if(Input.GetAxis("Brace") > 0)
            {
                ActivateFormation();
            }

        }

    }
}
