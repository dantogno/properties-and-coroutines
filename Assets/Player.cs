using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField]
    private float speed = 1;

    private float maxHitpoints = 100;
    private float currentHitpoints;

    private Rigidbody2D rigidbody;
    private float horizontalInput, verticalInput;


    public float CurrentHitpoints
    {
        get
        {
            return currentHitpoints;
        }
    }

    public float CurrentHitpointsAsPercentage
    {
        get
        {
            return currentHitpoints / maxHitpoints;
        }
    }


    // Use this for initialization
    void Start () 
	{
        currentHitpoints = maxHitpoints;
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        GetInput();
        HandleMovement();
	}

    private void HandleMovement()
    {
        rigidbody.velocity = 
            new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    public void TakeDamage(float amount)
    {
        currentHitpoints -= amount;
    }
}
