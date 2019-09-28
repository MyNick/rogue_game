using System;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
	[SerializeField] private string NextRoom;
	

	private void OnTriggerEnter2D(Collider2D other)
	{
		SceneLoader.Reload(NextRoom);
		GetComponent<Collider2D>().enabled = false;
	}
}
