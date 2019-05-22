using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveS = 1000.0f;

    Rigidbody2D rigidB;
    Animator anim;

    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = rigidB.velocity;

        currentVelocity = new Vector2(xAxis * moveS, currentVelocity.y);

        rigidB.velocity = currentVelocity;
    }

    private void Update()
    {
        Vector2 currentVelocity = rigidB.velocity;

        if (currentVelocity.x < 0.0f)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        anim.SetFloat("AbsVelocityX", Mathf.Abs(currentVelocity.x));
    }
}
