using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    BoxSpawner boxSpawner;
    void Start()
    {
        boxSpawner = FindObjectOfType<BoxSpawner>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndTurn()
    {
        if (boxSpawner.BoxExist())
        {
            boxSpawner.MoveBoxDown();
        }
        if (boxSpawner.BoxOnTheLimit())
        {
            print("END GAME");
        }
    }

}
