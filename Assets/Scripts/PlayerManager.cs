using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> balls = new List<GameObject>();
    [SerializeField] int currentBallIndex = 0;
    [SerializeField] Transform ballContainer = default;
    Ball currentBall;

    private void Start()
    {
        currentBallIndex = 0;
        currentBall = ballContainer.transform.GetChild(0).gameObject.GetComponent<Ball>();
    }

    void Update()
    {
        if (Input.GetButtonDown("ChangeBall"))
        {
            currentBallIndex = (currentBallIndex == balls.Count - 1) ? 0 : currentBallIndex+1;
            GameObject ballClone = (GameObject) Instantiate(balls[currentBallIndex], currentBall.transform.position, currentBall.transform.rotation, ballContainer);
            Vector3 velocity = currentBall.Velocity;
            Destroy(currentBall.gameObject);
            currentBall = ballClone.GetComponent<Ball>();
            currentBall.Velocity = velocity;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        currentBall.Move(movement);
    }
}
