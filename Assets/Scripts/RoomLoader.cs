using System;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
	[SerializeField] private string NextRoom;
	[SerializeField] private Sprite open;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		GetComponent<Collider2D>().isTrigger = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		SceneLoader.Reload(NextRoom);
		Destroy(gameObject);
	}

	public void ChangeSprite()
	{
		spriteRenderer.sprite = open;
	}
}
