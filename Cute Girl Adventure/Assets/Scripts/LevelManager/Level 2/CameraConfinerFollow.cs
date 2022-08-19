using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfinerFollow : MonoBehaviour
{
    public Transform camPosition;
    public Trigger girlTrigger;
    public GirlMovement girlMovement;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>();
        girlTrigger = GameObject.FindWithTag("Player").GetComponent<Trigger>();
        girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (girlTrigger.enteringCloudy && transform.position.y < camPosition.transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, camPosition.transform.position.y);
        }    
        if(camPosition == null)
        {
            camPosition = GameObject.FindWithTag("Star").GetComponent<Transform>();
        }
        if (girlTrigger == null)
        {
            girlTrigger = GameObject.FindWithTag("Player").GetComponent<Trigger>();
        }
        if (girlMovement == null)
        {
            girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
        }
    }
}
