using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Object/LevelData", order = 1)]
// In LevelDataSO, we create a star group. 
// We create classes where we can define values ​​such as starting position and distance for stars, planets and satellites in this star group.
public class LevelDataSO : ScriptableObject
{
    public List<StarData> StarGroups;
}

[System.Serializable]
public class StarData
{
    public StarDataSO starData;
    public Vector3 starPosition;
    [SerializeField] public List<PlanetData> Planets;
}

[System.Serializable]
public class PlanetData
{
    public PlanetDataSO planetData;
    public float distanceToStar;
    public List<SatelliteData> Satellites;
}

[System.Serializable]
public class SatelliteData
{
    public SatelliteDataSO satelliteData;
    public float distanceToPlanet;
}
