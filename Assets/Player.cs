using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float damageCooldown = 2;

    private float maxHitpoints = 100;
    private float currentHitpoints;
    private bool isInvulnerable;
    private Rigidbody2D rigidbody;
    private float horizontalInput, verticalInput;
    private SpriteRenderer spriteRenderer;


    public float CurrentHitpoints
    {
        get
        {
            return currentHitpoints;
        }

        private set
        {
            currentHitpoints = value;

            if (currentHitpoints < 0)
                currentHitpoints = 0;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () 
	{
        GetInput();
        HandleMovement();
	}

    private IEnumerator HandleDamageCooldown()
    {
        isInvulnerable = true;
        StartCoroutine(DoBlinkInvulnerableEffect());
        yield return new WaitForSeconds(damageCooldown);
        isInvulnerable = false;
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
        if (!isInvulnerable)
        {
            CurrentHitpoints -= amount;
            StartCoroutine(HandleDamageCooldown());
        }
    }

    private IEnumerator DoBlinkInvulnerableEffect()
    {
        Color transparentColor = new Color(1, 1, 1, 0);
        Color regularColor = spriteRenderer.color;

        float blinkInterval = 0.25f;

        while (isInvulnerable)
        {
            spriteRenderer.color = transparentColor;
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.color = regularColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
