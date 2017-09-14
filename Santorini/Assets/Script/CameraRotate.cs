using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {
    bool mouseClickjudge;
    float cameraRotateSpeed;
    // Use this for initialization
    void Start () {
        cameraRotateSpeed = 20;
        transform.RotateAround(new Vector3(8, 0, 8), Vector3.up, 180);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)) { mouseClickjudge = true; }
        if (Input.GetMouseButtonUp(1)) { mouseClickjudge = false; }
        if (mouseClickjudge) { transform.RotateAround(new Vector3(8,0,8), Vector3.up, Input.GetAxis("Mouse X") * cameraRotateSpeed); }
    }
}
