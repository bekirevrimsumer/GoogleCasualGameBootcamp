using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetDataSO", menuName = "Scriptable Object/PlanetDataSO", order = 1)]
//PlanetDataSO inherits from CelestialDataSO. We also define the variables required for the planet here.
public class PlanetDataSO : CelestialDataSO
{
    public float planetRotateSpeed;
    public float planetSelfRotateSpeed;
    public GameObject parentPlanet;
}
