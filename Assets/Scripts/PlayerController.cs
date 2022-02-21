using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float gravityConstant = -9.81f;
    [SerializeField] float groundCheckRadius = 0.5f;
    [SerializeField] float jumpForce = 50f;

    [SerializeField] Vector3 currentGravityValue; //Serializing this only to view in inspector
    private Vector3 inputValue;

    bool isGrounded = false;
    public bool canMove = false;

    public CharacterController playerController;
    public Transform gorungCheckerObj;
    public LayerMask groundLayer;
    public CollectibleSpawnner spawnnerManager;
    public TimeManager timer;
    public GameManager manager;

    private void Update() {

        //=================================================================================== Handling Movement//
        if (canMove)
        {
            ////Getting Input.
            float tempX = Input.GetAxis("Horizontal");
            float tempY = Input.GetAxis("Vertical");

            isGrounded = Physics.CheckSphere(gorungCheckerObj.position, groundCheckRadius, groundLayer);

            ////Getting Localposition of player and multiplying with input.
            Vector3 sideWaysVector = transform.right * tempX;
            Vector3 backAndForthVector = transform.forward * tempY;


            ////Adding Resultant of above vectors to get resultant move vector
            inputValue = sideWaysVector + backAndForthVector;


            ////Moving player through PlayerCharacterController Component.
            playerController.Move(inputValue * moveSpeed * Time.deltaTime);


            ////Applying gravity to come down while player jumps
            if (isGrounded == false && currentGravityValue.y < 0)
            {
                currentGravityValue.y = -2f;
            }


            ////Getting Input to Jump
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                currentGravityValue.y = Mathf.Sqrt(jumpForce * -2f * gravityConstant);
            }


            ////Constantly updating gravity based on whether player is grounded or not
            currentGravityValue.y += gravityConstant * Time.deltaTime;
            playerController.Move(currentGravityValue * Time.deltaTime);
        } 
        //=================================================================================================//
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Coin")
        {
            manager.IncrementScore();
            timer.AddExtraTime();
            hit.gameObject.SetActive(false);
            spawnnerManager.isSpawned = true;
        }
    }

}
