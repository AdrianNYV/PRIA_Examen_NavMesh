using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    float mainSpeed = 100.0f; 
    float shiftAdd = 250.0f; 
    float maxShift = 1000.0f; 
    private Vector3 lastMouse = new Vector3(255, 255, 255); 
    private float totalRun = 1.0f;

    void Update() {  
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0) { 
            if (Input.GetKey(KeyCode.LeftShift)) {
                totalRun += Time.deltaTime;
                p = p * totalRun * shiftAdd;
                p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
            } else {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                p = p * mainSpeed;
            }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space)) { 
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            } else {
                transform.Translate(p);
            }
        }
    }

    private Vector3 GetBaseInput() { 
        Vector3 p_Velocity = new Vector3();
        //Zoom In
        if (Input.GetKey(KeyCode.Q)) {
            p_Velocity += new Vector3(0, 0, 1);
        }
        //Zoom Out
        if (Input.GetKey(KeyCode.E)) {
            p_Velocity += new Vector3(0, 0, -1);
        }
        //Move To The Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        //Move To The Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            p_Velocity += new Vector3(1, 0, 0);
        }
        //Move Up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            p_Velocity += new Vector3(0, 1, 0);
        }
        //Move Down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            p_Velocity += new Vector3(0, -1, 0);
        }
        return p_Velocity;
    }
}