using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallCannon : MonoBehaviour
{
    // Start is called before the first frame update
    int maxBall = 10;
    int currentBall;
    public TextMesh numberBallText;
    public Ball ballPrefab;
    public Transform lookAt;
    Game game;
    void Start()
    {
        currentBall = maxBall;
        numberBallText.text = "x" + currentBall;
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
       // di chuyển chuột thì ballcannon follow 
        Vector2 directionShoot = new Vector2(lookAt.position.x - transform.position.x, lookAt.position.y-transform.position.y);
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10; // Set this to the distance from the camera to the gunPivot object

            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos.z = 0;

            Vector3 direction = lookPos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            //Quaternion rotation = Quaternion.AngleAxis(Mathf.Clamp(angle, -80,80), Vector3.forward);
            transform.rotation = rotation;
            
        } 
        //shoot ball
        if (Input.GetMouseButtonUp(0) && currentBall == maxBall)
        {
            StartCoroutine(Shoot(directionShoot, maxBall));
        }        
    }
    private IEnumerator Shoot(Vector3 direction, int count)
    {
        for(int i = 0; i < count; i++)
        {
            Ball ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            currentBall--;
            numberBallText.text = "x" + currentBall;
            ball.direction = direction;
            ball.speed = 10;
            ball.startPos = transform.position;
            yield return new WaitForSeconds(0.1f);
        }
        while(currentBall != maxBall)
            yield return null;
        game.EndTurn();

    }
    public void GainBall()
    {
        currentBall++;
        numberBallText.text = "x" + currentBall;
    }

}
 