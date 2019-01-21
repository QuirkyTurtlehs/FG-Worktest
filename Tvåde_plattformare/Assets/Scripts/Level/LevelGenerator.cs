using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{
    // Use this for initialization

    #region Variables
    [SerializeField] private GameObject groundTop;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject currentTile;

    [SerializeField] private int levelWidth;
    [SerializeField] private int levelHight;
    [SerializeField] private int heightMultiplier;
    [SerializeField] private int heightAddition;
    [SerializeField] private float smoothness;
    [SerializeField] private float seed;
    #endregion

    void Start()
    {
        seed = Random.Range(-10000F, 10000F);

        CreateLevel();        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateLevel()
    {       
        for (int i = 0; i < levelWidth; i++)
        {
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i + transform.position.x) / smoothness) * heightMultiplier) + heightAddition;
            for (int j = 0; j < h; j++)
            {
                if (j < h - 1)
                    currentTile = ground;                
                else
                    currentTile = groundTop;
                
                GameObject newTile = Instantiate(currentTile, Vector3.zero, Quaternion.identity) as GameObject;
                newTile.transform.parent = this.gameObject.transform;
                newTile.transform.localPosition = new Vector3(i, j);
            }
        }
    }
}
