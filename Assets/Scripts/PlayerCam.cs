using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Start is called before the first frame update
    public float dirX;
    public float dirY;
    public Transform orientation;

    float xRot;
    float yRot;
    
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X")*Time.deltaTime*dirX;
        float mouseY = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*dirY;

        yRot += mouseX;
        xRot -= mouseY;
    
    }
}
