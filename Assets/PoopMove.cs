using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopMove : MonoBehaviour
{

    public float speed;
    public RigidBody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
    //death
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement.normalized * speed * Time.DeltaTime);
    }
}
