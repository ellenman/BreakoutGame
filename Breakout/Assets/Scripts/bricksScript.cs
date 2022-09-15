using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricksScript : MonoBehaviour
{
    public int points;
    public int hitsUntilBreak;
    public Sprite hitSprite;

    public void BreakTheBrick()
    {
        hitsUntilBreak--;
        //change the sprite
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
   
    
}
