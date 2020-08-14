using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour {
    public Vector3 start;
    public Vector3 end;
    public float deltaX = 0f;
    public float deltaY = 0f;
    public Camera mainCamera;
    public GameObject UI;
    public GameObject endUI;
    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            start = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp (0)) {
            end = Input.mousePosition;
            deltaX = (start - end).x;
            deltaY = (start - end).y;
        }
        mainCamera.transform.Translate (deltaX * Time.deltaTime, deltaY * Time.deltaTime, 0f);
        Vector3 Vc1 = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y,5);
        //UI.transform.position =Vc1;
        //endUI.transform.position =Vc1;
        deltaX *= 0.1f;
        deltaY *= 0.1f;
    }
}