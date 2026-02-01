using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float movementSpeed;

    public int score;
    public TextMeshProUGUI scoreTxt;
    public LogicScript logic;
    private bool gameIsOver = false;

    public double speedOffset = 0.0; 

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    } // end of Start method

    // Update is called once per frame
    void Update()
    {

        speedOffset += 0.001; // To increase player's speed over time to increase difficulty

        if (gameIsOver)
        {
            rb.linearVelocity = new Vector3(0, 0, 0);
        } else
        {
            float movementInput = Input.GetAxis("Horizontal");

            rb.linearVelocity = new Vector3((float)(speed + speedOffset), 
                rb.linearVelocity.y, 
                -movementInput * ((float)(movementSpeed + speedOffset/2)));
        }

    } // end of Update method

    private void OnTriggerEnter(Collider other)
    {   
        // Player's score has increased by 1
        if (other.gameObject.tag == "Obstacle")
        {
            score++;
            scoreTxt.text = score.ToString();
        }
    } // end of OnTriggerEnter method

    private void OnCollisionEnter(Collision collision)
    {
        // Game is over
        if (collision.gameObject.tag == "Obstacle")
        {
            logic.gameOver();
            gameIsOver = true;
        }

    } // end of OnCollisionEnter method

} // end of Player class
