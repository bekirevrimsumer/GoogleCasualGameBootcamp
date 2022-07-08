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

    private Coroutine coroutine = null;

    void Start()
    {
        StartCoroutine(AutoRotate());
    }

    void Update()
    {
        if (autoRotate)
        {
            transform.RotateAround(sun.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

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
            transform.RotateAround(sun.transform.position, Vector3.up, horizontal);
        }

        if (Input.GetMouseButtonUp(0))
        {
            coroutine = StartCoroutine(AutoRotate());
        }
    }

    private void ClickPlanet()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Planet")))
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.gameObject.name);
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
            if (newZoom > 20 && newZoom < 100)
            {
                Camera.main.fieldOfView = newZoom;
            }
        }
    }

    IEnumerator AutoRotate()
    {
        yield return new WaitForSeconds(idleTime);
        autoRotate = true;
    }
}
