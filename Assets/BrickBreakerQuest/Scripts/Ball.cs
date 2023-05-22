using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector2 startPos;
    public Vector2 direction;
    public float radius;
    public LayerMask layerMask;
    BallCannon ballCannon;
    void Start()
    {
        ballCannon = FindObjectOfType<BallCannon>();    
        //direction = Random.insideUnitCircle.normalized; // tao goc ngau nhien trong pong
    }
    private void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        RaycastHit2D rayhit = Physics2D.CircleCast(transform.position, radius, direction, speed * Time.fixedDeltaTime,layerMask);
        if (rayhit.collider != null)
        {
            transform.position = rayhit.centroid;
            direction = Vector2.Reflect(direction, rayhit.normal);
            transform.position += (Vector3)direction * 0.2f;
            if (rayhit.collider.gameObject.CompareTag("Bottom Wall"))
            {
                MoveToStartPos();
                ballCannon.GainBall();
            }
            if (rayhit.collider.gameObject.CompareTag("Box"))
            {
                rayhit.collider.GetComponent<Box>().ReduceHp();
            }
        }
        else
        {
            transform.position = currentPos + (Vector3)direction* speed*Time.fixedDeltaTime;
        }
    }

   
    public void MoveToStartPos()
    {
        StartCoroutine(MoveToStartPosCoroutine());

    }
    IEnumerator MoveToStartPosCoroutine()
    {
        while (true)
        {
            Vector2 ballPos = transform.position;
            if (ballPos == startPos)
            {
                print("break");
                break;
            }
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);

    }
}
