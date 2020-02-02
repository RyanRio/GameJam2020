using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singable : Interactable 
{
    public override void interact() {
        singTo();
    }
    public abstract void singTo();

}
