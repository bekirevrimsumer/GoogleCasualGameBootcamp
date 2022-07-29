using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitiliazer : MonoBehaviour
{
    [SerializeField] LevelDataSO levelData;
    float randomTetha;
    Vector3 randomOrbitPosition;

    void Start()
    {
        InitializeLevel();
    }

    void InitializeLevel()
    {
        //I reach the number and distance information of the stars, planets and satellites in the star group via LevelDataSO and create the Level.
        foreach (var starGroup in levelData.StarGroups)
        {
            var star = InstantiateCelestial(starGroup.starData.CelestialPrefab, starGroup.starPosition, Quaternion.identity);
            foreach (var planet in starGroup.Planets)
            {
                GameObject planetObject = InitializePlanet(star, planet);

                foreach (var satellite in planet.Satellites)
                {
                    InitializeSatellite(planetObject, satellite);
                }
            }
        }
    }


    private GameObject InitializePlanet(GameObject star, PlanetData planet)
    {
        //the method by which we form planets relative to the target star
        float randomTetha = GetRandomTetha();
        Vector3 randomOrbitPosition = star.transform.position + GetRandomPositionOnOrbit(randomTetha, planet.distanceToStar);
        var planetObject = InstantiateCelestial(planet.planetData.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
        return planetObject;
    }

    private void InitializeSatellite(GameObject planetObject, SatelliteData satellite)
    {
        //the method by which we form satellites relative to the target planet
        randomTetha = GetRandomTetha();
        randomOrbitPosition = planetObject.transform.position + GetRandomPositionOnOrbit(randomTetha, satellite.distanceToPlanet);
        var satelliteObject = InstantiateCelestial(satellite.satelliteData.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
        satelliteObject.transform.parent = planetObject.transform;
    }

    GameObject InstantiateCelestial(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        //method that creates a new gameobject
        return Instantiate(prefab, position, rotation);
    }

    float GetRandomTetha()
    {
        return Random.Range(0, 360);
    }

    Vector3 GetRandomPositionOnOrbit(float tetha, float radius)
    {
        //method where we position the planet at a random position on the orbit according to the entered distance value
        return new Vector3(Mathf.Cos(tetha * Mathf.Deg2Rad) * radius, 0, Mathf.Sin(tetha * Mathf.Deg2Rad) * radius);
    }
}
