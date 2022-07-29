using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialMovement : MonoBehaviour
{
    public PlanetDataSO planetData;
    public GameObject targetObject;

    private float rotationAngle;

    private void Start()
    {
        targetObject = planetData.parentPlanet;
    }

    void Update()
    {
        //In PlanetDataSO I defined variables related to the rotational speeds of planets. I access these variables and make the planets rotate around itself and the parent planet
        transform.Rotate(new Vector3(0, planetData.planetSelfRotateSpeed, 0) * Time.deltaTime);

        //planets orbiting the sun
        transform.RotateAround(targetObject.transform.position, new Vector3(0, 1, 0), planetData.planetRotateSpeed * Time.deltaTime);

        //print to log when planet completes one revolution
        rotationAngle += Time.deltaTime * planetData.planetRotateSpeed;
        if (rotationAngle >= 360)
        {
            Debug.Log($"{planetData.CelestialName} has completed one revolution");
            rotationAngle = 0;
        }
    }
}
