using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Army armyScript;

    public float moveS = 1000.0f;

    Rigidbody2D rigidB;
    Animator anim;

    [SerializeField]
    private float backwardsMod;
    private float currBackMod;

    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        armyScript = GetComponent<Army>();
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = rigidB.velocity;

        currentVelocity = new Vector2(xAxis * moveS, currentVelocity.y);

        rigidB.velocity = currentVelocity * armyScript.speedModifier * currBackMod;
    }

    private void Update()
    {
        Vector2 currentVelocity = rigidB.velocity;

        if (currentVelocity.x < 0.0f)
        {
            currBackMod = backwardsMod;
        }
        else
            currBackMod = 1;

        anim.SetFloat("AbsVelocityX", Mathf.Abs(currentVelocity.x));
    }
}
