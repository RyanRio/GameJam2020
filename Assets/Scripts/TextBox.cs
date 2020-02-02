using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextBox : Interactable
{
    public string content;
    public Text text;
    private TextBox next;

    public override void interact()
    {
        text.text = content;
        Vector3 t = transform.position;
        t.x += 5;
        text.transform.position = t;
    }
}
 
