using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 xValue;
    public bool changeDirectionBool, leftFacing, changeIt, easing;
    Vector3 desiredPosition;
    Animator animator;
    [SerializeField] SpriteRenderer player;
    public float scoreIncrementInterval = 1f; // Time interval to increase score
    private float timeSinceLastIncrement;
    

    void Start()
    {
        leftFacing = true;  // Assuming the player starts facing left
        changeDirectionBool = !leftFacing;  // Set to the opposite of leftFacing initially
        
        DesiredPosition();
        animator = GetComponent<Animator>();

        // Set initial direction of the sprite
        player.flipX = !leftFacing;
        GameManager.score = 0;
        timeSinceLastIncrement = 0f;
        
    }

    
    void Update()
    {
        if(changeIt)
        {
            if (easing)
            {
                transform.position = Vector3.Lerp(transform.position, desiredPosition, .1f);
            }
            else {
                transform.position = desiredPosition;
            }

            if(Mathf.Abs(desiredPosition.x - transform.position.x) <= 0.1f)
            {
                Debug.Log("Change Grav");
                changeIt = false;
                

            }



        }  

        timeSinceLastIncrement += Time.deltaTime;
        if (timeSinceLastIncrement >= scoreIncrementInterval)
        {
            GameManager.instance.IncreaseScore(1);
            timeSinceLastIncrement = 0f;
        }  

        
    }

    public void CallThisMethod()
    {
        DesiredPosition();
        changeDirection();
        
    }

    public void DesiredPosition()
    {
        desiredPosition = new Vector2(changeDirectionBool ? xValue.x : xValue.y, transform.position.y);
    }

    void changeDirection()
    {
        changeDirectionBool = !changeDirectionBool;
        if(changeDirectionBool != leftFacing)
        {
            changeIt = true;
            leftFacing = changeDirectionBool;
            player.flipX = !leftFacing;
            
            

           

        }

        
    }

    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Spike")
        {
           GameManager.instance.GoToMainMenu();
        
        }
        
    }

  

}
