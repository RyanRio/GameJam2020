using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    private Vector2 prevDirection;
    public int interactDistance;

    public LayerMask interactable;
    private bool e = false;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            e = true;
        }
        else if (e)
        {
            e = false;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(x) > Mathf.Epsilon || Mathf.Abs(y) > Mathf.Epsilon)
        {
            print("moving");
            prevDirection.x = x;
            prevDirection.y = y;
        }

        rb.MovePosition(rb.position + new Vector2(x, y).normalized * Time.deltaTime * speed);
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if(e)
        {
            Vector2 end = transform.position + new Vector3(interactDistance * prevDirection.x,interactDistance * prevDirection.y);
            print("start" + transform.position);
            print("end: " + end);
            Debug.DrawLine(transform.position, end, Color.red, 100f);

            print("hit e");
            boxCollider.enabled = false;
            RaycastHit2D hit;
            HitLayerObject.Hit(interactable, transform.position, end, out hit);

            if (hit.transform != null)
            {
                Interactable comp = hit.transform.GetComponent<Interactable>();
                comp.interact();
            }
            boxCollider.enabled = true;
        }
    }
}
