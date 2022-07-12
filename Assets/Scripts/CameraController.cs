using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject sun;
    public float rotateSpeed;
    public float idleTime = 3f;
    public float scrollSpeed = 10f;
    public bool autoRotate = false;
    public List<GameObject> planets = new List<GameObject>();
    public GameObject targetPlanet;

    private Coroutine coroutine = null;

    void Start()
    {
        targetPlanet = sun;
        StartCoroutine(AutoRotate());
    }

    void Update()
    {
        ChooseTargetPlanet();
        if (autoRotate)
        {
            transform.RotateAround(targetPlanet.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        transform.LookAt(targetPlanet.transform);

        DragRotate();

        ZoomCamera();
    }

    private void DragRotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            ClickPlanet();
        }

        if (Input.GetMouseButton(0))
        {
            autoRotate = false;
            var horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            transform.RotateAround(targetPlanet.transform.position, Vector3.up, horizontal);
            transform.LookAt(targetPlanet.transform);
        }

        if (Input.GetMouseButtonUp(0))
        {
            coroutine = StartCoroutine(AutoRotate());
        }
    }

    private void ClickPlanet()
    {
        //if a planet is clicked, a panel with information about that planet opens
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Planet")))
        {
            if (hit.transform != null)
            {
                UIManager.instance.OpenPanel(hit.transform.gameObject.GetComponent<RotatePlanet>().planetData.name);
            }
        }
    }

    private void ZoomCamera()
    {
        //zoom in zoom out with mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newZoom = Camera.main.fieldOfView - scroll * scrollSpeed;
            if (newZoom > 5 && newZoom < 100)
            {
                Camera.main.fieldOfView = newZoom;
            }
        }
    }

    private void ChooseTargetPlanet()
    {
        //we set the sun or any planet as a targetPlanet
        // Camera focusing on planets when pressing keys 1 to 8
        var input = Input.inputString;
        switch (input)
        {
            case "1":
                targetPlanet = planets[0];
                break;
            case "2":
                targetPlanet = planets[1];
                break;
            case "3":
                targetPlanet = planets[2];
                break;
            case "4":
                targetPlanet = planets[3];
                break;
            case "5":
                targetPlanet = planets[4];
                break;
            case "6":
                targetPlanet = planets[5];
                break;
            case "7":
                targetPlanet = planets[6];
                break;
            case "8":
                targetPlanet = planets[7];
                break;
            case "0":
                targetPlanet = sun;
                break;
        }
    }


    IEnumerator AutoRotate()
    {
        // If there is no interaction for 3 seconds, the camera automatically rotates around the targetPlanet.
        yield return new WaitForSeconds(idleTime);
        autoRotate = true;
    }
}
