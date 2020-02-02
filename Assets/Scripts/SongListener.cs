using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SongListener : MonoBehaviour
{

    int[] myID = new int [4];

    public void listenToSong(int[] songID) {
        
        for(int i = 0; i < myID.Length; i++) {
            if(myID[i] != songID[i]) {
                return;
            }
        }

        act();
    }

    public abstract void act();
}
