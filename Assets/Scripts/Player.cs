using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    private Vector2 direction;

    public LayerMask interactable;
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
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if(Input.GetKeyUp(KeyCode.E))
        {
            print("hit e");
            boxCollider.enabled = false;
            RaycastHit2D hit;
            HitLayerObject.Hit(interactable, transform.position, new Vector2(transform.position.x, transform.position.y) + new Vector2(5, 0), out hit);

            if (hit.transform != null)
            {
                Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + new Vector2(5, 0), Color.red, 100f);
                Interactable comp = hit.transform.GetComponent<Interactable>();
                comp.interact();
            }
            boxCollider.enabled = true;
        }
    }
}
