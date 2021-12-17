using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloors : MonoBehaviour
{
    private float speed = -5.0f;
    private Vector3 startPos;
    private float floorWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        floorWidth = GetComponent<BoxCollider>().size.x / 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(startPos * speed * Time.deltaTime);

        if(transform.position.x > startPos.x + floorWidth)
        {
            transform.position = startPos;
        }
    }
}
