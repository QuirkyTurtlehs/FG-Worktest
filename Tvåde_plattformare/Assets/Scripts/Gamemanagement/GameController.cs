using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int currentScene;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadSceneAsync(currentScene, LoadSceneMode.Single);
        }

	}
}
