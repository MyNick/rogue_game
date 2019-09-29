using System;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 2;
    public float damage = 1;
    private Player player;
    [SerializeField] private float speed = 2;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        Vector3 movement = (transform.position - player.transform.position).normalized;
        transform.position += Time.deltaTime * speed * -movement;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
            Die();
    }

    private void Die()
    {
        if(UnityEngine.Random.Range(0, 100) > 80)
            Instantiate(GameManager.Instance.GetRandomPickup().gameObject,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
