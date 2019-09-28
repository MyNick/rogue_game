using System;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
	[SerializeField] private string NextRoom;
	private void OnMouseDown()
	{
		SceneLoader.Reload(NextRoom);
	}
}
