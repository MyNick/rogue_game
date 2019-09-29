using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Singelton

	public static GameManager Instance;
	#endregion
	
	#region Constants
	
	#endregion
	
	#region Private Members
	
	#endregion
	
	#region Inspector Members

	[SerializeField] private Pickup[] pickups;
	#endregion
	
	#region Events
	
	#endregion
	
    void Start()
    {
	    Instance = this;
    }

    public Pickup GetRandomPickup()
    {
	    return pickups[Random.Range(0, pickups.Length)];
    }
}
