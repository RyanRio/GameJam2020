using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + direction.normalized * Time.deltaTime * speed);

        RaycastHit2D hit;
        HitLayerObject.Hit<Interactable>(LayerMask.NameToLayer("Interactable"), transform.position, new Vector2(1, 0), out hit);

        if(hit.transform != null)
        {
            Interactable comp = hit.transform.GetComponent<Interactable>();
            comp.interact();
        }
    }
}
