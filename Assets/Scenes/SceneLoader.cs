using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

	private static SceneLoader Instance;

	private GameObject Player;
	
	private static Queue<string> loadedScenes = new Queue<string>();

	void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(this);
		//SceneManager.LoadSceneAsync("AutoSceneLeftUp", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("AutoSceneRightUp", LoadSceneMode.Additive);

		//loadedScenes.Enqueue("AutoSceneLeftUp");
		loadedScenes.Enqueue("AutoSceneRightUp");
	}


	public static void Reload(string toLoad)
	{
		if (loadedScenes.Count >= 2)
		{
			SceneManager.UnloadSceneAsync(loadedScenes.Dequeue());
		}
		SceneManager.LoadSceneAsync(toLoad, LoadSceneMode.Additive);
		loadedScenes.Enqueue(toLoad);
	}
}
