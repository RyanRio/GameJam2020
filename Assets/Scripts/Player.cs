using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{


  private class Movement
  {
    //idk what class this is but x;
    // same y;

    protected apply(Player player) {
      if(this.validMove(player)){
        player.x += this.posX;
        player.y += this.posY;
      }
    }

    protected validMove(player) {
      // uhhhhh check if the movement hits an obstacle i guess
    }
  }

  public void playSong()
  {
    // song stuff
  }

  public void move(Movement move)
  {
    move.apply(this);
  }
}
