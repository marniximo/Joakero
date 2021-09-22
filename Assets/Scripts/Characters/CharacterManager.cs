using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public bool selected = false;
    public float speed = 1f;
    public float progression = 0;
    public GameController gameController;

    private bool ps = false;
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        var renderer = gameObject.GetComponent<Renderer>();
        defaultColor = renderer.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            if (!ps) 
            {
                gameObject.transform.localScale = new Vector3(100, 100, 10);
                var renderer = gameObject.GetComponent<Renderer>();
                renderer.material.SetColor("_Color", defaultColor * 3f);
                ps = true;
            }
        }
        else 
        {
            if (ps) {
                gameObject.transform.localScale = new Vector3(80, 80, 10);
                var renderer = gameObject.GetComponent<Renderer>();
                renderer.material.SetColor("_Color", defaultColor);
                ps = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (selected) {
                gameController.UseTurn();
            }
        }
    }
}
