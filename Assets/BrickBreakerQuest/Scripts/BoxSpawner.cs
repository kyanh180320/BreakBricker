using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int endX;
    public int startX;
    public int startY;
    public int endY;
    public Box boxPrefab;
    private void Start()
    {
        for (int i = startX; i < endX; i++)
        {
            for(int j = startY; j < endY; j++)
            {
                Vector2 pos = new Vector2(i, j);
                Box newBox = Instantiate(boxPrefab, pos, Quaternion.identity);
            }
        }
    }
    public void MoveBoxDown()
    {
        Box[] boxes = FindObjectsOfType<Box>(); 
        foreach (Box box in boxes)
        {
            box.transform.position += Vector3.down;
        }

    }
    public bool BoxExist()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        return boxes.Length > 0;
    }
    public bool BoxOnTheLimit()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach (Box box in boxes)
        {
            if (box.transform.position.y < -8)
            {
                return true;
            }
        }
        return false;
    }
}
