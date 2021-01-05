using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public bool isAlive = false;
    public int numOfNeighbours = 0;

    public void SetAlive(bool alive)
    {
        isAlive = alive;
        GetComponent<SpriteRenderer>().enabled = alive;
    }

}
