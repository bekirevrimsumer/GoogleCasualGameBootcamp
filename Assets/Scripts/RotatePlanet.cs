using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public PlanetData planetData;
    public GameObject sun;

    private void Start()
    {
        sun = GameObject.Find("Sun");
    }

    void Update()
    {
        //rotation of planets on their own axis
        transform.Rotate(new Vector3(0, planetData.planetSelfRotateSpeed, 0) * Time.deltaTime);

        //planets orbiting the sun
        transform.RotateAround(sun.transform.position, new Vector3(0, 1, 0), planetData.planetRotateSpeed * Time.deltaTime);


    }
}
