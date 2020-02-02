using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    private Vector2 prevDirection;
    public int interactDistance;

    public LayerMask interactable;
    private bool e = false;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            if (Mathf.Abs(x) > 0)
            {
                y = 0;
            }
            prevDirection.x = x;
            prevDirection.y = y;

            if (x > 0)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else if (x < 0)
            {
                spriteRenderer.sprite = sprites[1];
            }
            if (y > 0)
            {
                spriteRenderer.sprite = sprites[2];
            }
            else if (y < 0)
            {
                spriteRenderer.sprite = sprites[3];
            }
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
