using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidController : MonoBehaviour
{
    public float speed = 250f;
    public List<GameObject> planets = new List<GameObject>();
    public GameObject targetPlanet;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

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
        return planets[randomIndex];
    }

    void MoveToPlanet(GameObject targetPlanet)
    {
        // Vector3 direction = targetPlanet.transform.position - transform.position;
        // direction.Normalize();
        // _rigidbody.AddForce(direction * speed);

        transform.position = Vector3.MoveTowards(transform.position, targetPlanet.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Astreoid hit " + other.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("Planet"))
        {
            Destroy(gameObject);
        }
    }
}
