using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    private float speed = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -85 || transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
