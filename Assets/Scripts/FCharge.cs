using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCharge : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
      
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControl)
        {

            if(Input.GetAxis("Charge") > 0)
            {
                ActivateFormation();
            }

        }
        
    }

    
}
