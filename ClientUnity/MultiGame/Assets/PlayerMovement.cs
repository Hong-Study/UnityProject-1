using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
     
    void FixedUpdate()
    {
        Vector3 Pos = new Vector3();
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Pos.x -= Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Pos.x += Speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Pos.z += Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Pos.z -= Speed;
        }

        rigid.velocity = Vector3.Lerp(rigid.velocity, Pos, 2f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube")
        {
            Destroy(other.gameObject);
        }
    }
}
