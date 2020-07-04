using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public GameObject fallingSpherePrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;

    bool cubeFalling = true;

    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    Vector2 screenHalfSizeWorldUnits;

    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        
    }

    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            // Difficulty returnerar 0 elr 1 och math lerp kollar vilken som som är value med Value = a +(b-a)*p
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y); // tar ut en random size ur en vektor2
            Vector2 spawnPosition = new Vector2(Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            
            if(cubeFalling == true)
            {
                GameObject newBlock = (GameObject)Instantiate(fallingSpherePrefab, spawnPosition, Quaternion.Euler(new Vector3 (0,0,1) * spawnAngle));
                newBlock.transform.localScale = Vector2.one * spawnSize;
                cubeFalling = false;
            }
            else
            {
                GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(new Vector3 (0,0,1) * spawnAngle)); //vector3.foward funkar ist för new vector3
                newBlock.transform.localScale = Vector2.one * spawnSize;
                cubeFalling = true;
            }
            
        }
    }
}
