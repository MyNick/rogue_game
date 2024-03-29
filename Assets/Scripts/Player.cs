﻿using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float offsetX = 0.63f;
    
    [SerializeField]
    private float speed;

    [SerializeField] private float health = 3;
    [SerializeField] private float damage = 1;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI damageText;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private int walk;
    private bool looking_right = true;
    private int attack;
    private CapsuleCollider2D sword;
    
    
    private float walkTimer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        walk = Animator.StringToHash("Walk");
        attack = Animator.StringToHash("Attack");
        sword = GetComponent<CapsuleCollider2D>();
        sword.enabled = false;
    }

    void Update()
    {
        walkTimer -= Time.deltaTime;
        if(walkTimer <= 0)
            MovementLogic();
        if (Input.GetKeyDown(KeyCode.Space) && walkTimer <= 0)
        {
            sword.enabled = true;
            anim.SetTrigger(attack);
            walkTimer = 0.5f;
        }
        
    }

    private void MovementLogic()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        anim.SetBool(walk, movement != Vector3.zero);
        if (movement.x != 0)
        {
            looking_right = movement.x > 0;

        }

        spriteRenderer.flipX = !looking_right;
        sword.offset =  new Vector2(offsetX * (spriteRenderer.flipX ? -1 : 1), sword.offset.y);

        transform.position += movement * Time.deltaTime * speed;
        sword.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() && walkTimer >= 0)
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            sword.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Enemy>())
            TakeDamage(other.gameObject.GetComponent<Enemy>().damage);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthText.text = health.ToString();
        if(health <= 0)
            Destroy(gameObject);
    }

    public void PowerUp(string boostFor, int boostAmount)
    {
        health += boostFor == "Health" ? boostAmount : 0;
        damage += boostFor == "Damage" ? boostAmount : 0;
        healthText.text = health.ToString();
        damageText.text = damage.ToString();
    }
}
