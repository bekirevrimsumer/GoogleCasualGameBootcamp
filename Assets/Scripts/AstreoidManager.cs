using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidManager : MonoBehaviour
{
    public float rangeX = 300f;
    public float rangeY = 300f;
    public float rangeZ = 1200f;
    public GameObject astreoidPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnAstreoid();//Creates asteroid when space key is pressed
        }
    }

    void SpawnAstreoid()
    {
        Vector3 pos = RandomPosition();
        Instantiate(astreoidPrefab, pos, Quaternion.identity);
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), Random.Range(-rangeZ, rangeZ));// function that generates random position within the specified range of values
    }
}
