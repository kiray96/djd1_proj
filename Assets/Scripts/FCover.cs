using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCover : Formation
{

   
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        currFormation = EnumArmyStates.Cover;        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControl)
        {

            if(Input.GetAxis("Cover") > 0)
            {
                ActivateFormation();
            }

        }

    }
}
