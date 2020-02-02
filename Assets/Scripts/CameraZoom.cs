using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer background;
    public Camera cam;
    void Start()
    {

        float orthoSize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;
        cam.main.orthographicSize = orthoSize;
    }


}
