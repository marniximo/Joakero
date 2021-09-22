using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraObject;
    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        movement = movement * Time.deltaTime * cameraSpeed;
        cameraObject.transform.Translate(movement);

    }


}
