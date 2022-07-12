using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidController : MonoBehaviour
{
    public float speed = 250f;
    public List<GameObject> planets = new List<GameObject>();
    public GameObject targetPlanet;
    public GameObject explosion;

    private void Start()
    {

        // We find the ones with TrackingObject tags on the scene and add them to our planets list.
        var planetObjects = GameObject.FindGameObjectsWithTag("TrackingObject");
        foreach (var planet in planetObjects)
        {
            planets.Add(planet);
        }
        targetPlanet = ChooseRandomPlanet();
    }

    private void Update()
    {
        MoveToPlanet(targetPlanet);
    }

    GameObject ChooseRandomPlanet()
    {
        int randomIndex = Random.Range(0, planets.Count);
        return planets[randomIndex]; //targets a random one among the planets
    }

    void MoveToPlanet(GameObject targetPlanet)
    {
        //With MoveTowards to the target selected planet, the asteroid is made to move.
        transform.position = Vector3.MoveTowards(transform.position, targetPlanet.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the asteroid hits a planet, we destroy the asteroid and create an explosion effect with particle effect. After 4 seconds we also destroy the particle effect
        if (other.gameObject.layer == LayerMask.NameToLayer("Planet"))
        {
            var explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionInstance.transform.parent = other.transform;
            Destroy(gameObject);
            Destroy(explosionInstance, 4f);
        }
    }
}
