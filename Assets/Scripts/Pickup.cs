using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] private string boostFor;
	[SerializeField] private int boostAmount;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Player>())
		{
			other.GetComponent<Player>().PowerUp(boostFor, boostAmount);
			Destroy(gameObject);
		}
	}
}
