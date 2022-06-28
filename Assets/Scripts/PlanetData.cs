using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Planet")]
public class PlanetData : ScriptableObject
{
    //scriptable object that records the names of the planets, their axis velocities and their velocities around the sun
    public string planetName;
    public float planetRotateSpeed;
    public float planetSelfRotateSpeed;
}