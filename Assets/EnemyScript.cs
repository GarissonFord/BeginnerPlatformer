using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			Destroy (other.gameObject);
			Invoke("RestartGame", 5f);
		}
	}

	void RestartGame()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
