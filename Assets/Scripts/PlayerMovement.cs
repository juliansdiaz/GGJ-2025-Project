using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] float movementSpeed = 5.5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] LayerMask groundMask;
     [SerializeField] Animator animationController;

    public static bool playerIsInDamageArea;
    CharacterController playerController;
    float gravityScale = -9.81f;
    Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>(); //Call CharacterController component   
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //Get player input
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        if (xMove > 0||zMove > 0 )
         {
            animationController.SetBool("IS movement?",true);
        }
        else 
          {
           animationController.SetBool("IS movement?",false);
        }

        //Set movement direction
        Vector3 movementdir = transform.right * xMove + transform.forward * zMove;
        playerController.Move(movementdir * movementSpeed * Time.deltaTime);

        //Make gravity affect player
        playerVelocity.y += gravityScale * Time.deltaTime;

        //Move player
        playerController.Move(playerVelocity * Time.deltaTime);

        //Player sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerController.Move(movementdir * (movementSpeed * 0.8f) * Time.deltaTime);
        }
    }

   
}
