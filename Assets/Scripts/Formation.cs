using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{
    protected Army armyScript;

    [SerializeField]
    protected float speedMod;

    [SerializeField]
    protected float atkMod;

    [SerializeField]
    protected float defMod;

    [SerializeField]
    protected float massMod;

    protected EnumArmyStates currFormation;

    [SerializeField]
    protected bool playerControl = true;

    protected void Start()
    {
        armyScript = GetComponent<Army>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMod = Mathf.Clamp(speedMod, 0, 2);
        atkMod = Mathf.Clamp(atkMod, 0, 1);
        defMod = Mathf.Clamp(defMod, 0, 1);
        massMod = Mathf.Clamp(massMod, 0, 1);
    }

    protected void ActivateFormation()
    {
        armyScript.currentState = currFormation;
        armyScript.defenseModifier = defMod;
        armyScript.speedModifier = speedMod;
        armyScript.attackModifier = atkMod;
        armyScript.massModifier = massMod;

    }

   
}
