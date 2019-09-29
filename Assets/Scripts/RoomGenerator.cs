using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyPrefab;

	private GameObject enemy;

	[SerializeField]
	private RoomLoader door;
    void OnEnable()
    {
	    enemy = Instantiate(enemyPrefab, transform.position + new Vector3(0,0, -1), Quaternion.identity);
    }
	
    void Update()
    {
	    if (door != null)
	    {
		    if (enemy == null)
		    {
			    door.GetComponent<RoomLoader>().ChangeSprite();
			    door.GetComponent<Collider2D>().isTrigger = true;
		    }
	    }
    }
}
