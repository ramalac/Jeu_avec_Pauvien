using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private int numberOfStep = 0;
    private int stop = 600;
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool inTransition = GameObject.Find("HumanMale_Character_FREE").GetComponent<Animator>().IsInTransition(0);
        bool moveOn = GameObject.Find("HumanMale_Character_FREE").GetComponent<Animator>().GetBool("hasBow");
        if (moveOn && numberOfStep < stop)
        {
            numberOfStep++;
            CharacterController controller = GetComponent<CharacterController>();

            groundedPlayer = controller.isGrounded;

            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(0, 0, 1);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        if (moveOn && numberOfStep >= stop)
        {
            GameObject.Find("HumanMale_Character_FREE").GetComponent<Animator>().SetBool("isFrontOfTheWall", true);
            GameObject.Find("HumanMale_Character_FREE").GetComponent<Animator>().SetBool("hasBow", false);
            Destroy(GameObject.Find("breakableFenceFirstLevel"));
        }
            

    }
}
