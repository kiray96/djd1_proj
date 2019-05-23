using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{
    float speedMod;
    float atkMod;
    float defMod;
    float massMod;

    EnumArmyStates currFormation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedMod = Mathf.Clamp(speedMod, 0, 1);
        atkMod = Mathf.Clamp(atkMod, 0, 1);
        defMod = Mathf.Clamp(defMod, 0, 1);
        massMod = Mathf.Clamp(massMod, 0, 1);
    }
}
