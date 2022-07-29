using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CelestialDataSO", menuName = "Scriptable Object/CelestialDataSO", order = 1)]
//I created a basic scriptable object for all celestial objects.
public abstract class CelestialDataSO : ScriptableObject
{
    public string CelestialName;
    public string CelestialDescription;
    public GameObject CelestialPrefab;

    public override string ToString()
    {
        return string.Format("{0} - {1}", CelestialName, CelestialDescription);
    }
}
