﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health = 100;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}