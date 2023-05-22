using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public TextMesh textMesh;
    void Start()
    {
        textMesh.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
   
    public void ReduceHp()
    {
        hp--;
        if (hp < 1)
        {
            Destroy(gameObject);
        }
        else
        {
            textMesh.text = hp.ToString();
        }

    }
}
