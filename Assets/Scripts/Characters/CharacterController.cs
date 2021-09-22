using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            this.gameObject.transform.localScale = new Vector3(100,100,10);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(80, 80, 10);
        }
    }
}
