//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Player1 : MonoBehaviour
//{
//    public CharacterController cc;
//    public float speed = 5f;
//    public float rotate = 50f;
//    public float jumpForce = 5f;

//    Vector3 velocity;
//    float gravity = -9.81f;
//    bool isGrounded;
//    bool isGameOver = false;


//    public GameObject gameOver;

//    private void Start()
//    {
//        cc = GetComponent<CharacterController>();

//        if (gameOver != null)
//            gameOver.SetActive(false);
//    }

//    private void Update()
//    {
//        if (isGameOver) return;

//        isGrounded = cc.isGrounded;

//        float Horizontal = Input.GetAxis("Horizontal");
//        float Vertical = Input.GetAxis("Vertical");

//        transform.Rotate(0, Horizontal * rotate * Time.deltaTime, 0);

//        Vector3 forward = transform.forward * Vertical * speed * Time.deltaTime;

//        cc.Move(forward);


//        if (isGrounded && velocity.y < 0f)
//        {
//            velocity.y = -2f;
//        }

//        Jump();
//    }

//    void Jump()
//    {
//        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1)) && isGrounded)
//        {
//            velocity.y = jumpForce;
//        }

//        velocity.y += gravity * Time.deltaTime;

//        cc.Move(velocity * Time.deltaTime);
//    }

//    private void OnControllerColliderHit(ControllerColliderHit hit)
//    {
//        if (hit.gameObject.tag == "Water")
//        {
//            TriggerGameOver();
//        }
//    }

//    void TriggerGameOver()
//    {
//        isGameOver = true;

//        if (gameOver != null)
//            gameOver.SetActive(true);

//    }

//    IEnumerator RestartAfterDelay(float seconds)
//    {
//        yield return new WaitForSeconds(seconds);
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public CharacterController cc;
    public float speed = 5f;
    public float rotate = 50f;
    public float jumpForce = 5f;

    Vector3 velocity;
    float gravity = -30f;
    bool isGrounded;
    bool isGameOver = false;

    public GameObject gameOver;

    private AudioSource audioSource; 

    private void Start()
    {
        cc = GetComponent<CharacterController>();

        if (gameOver != null)
            gameOver.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isGameOver) return;

        isGrounded = cc.isGrounded;

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        transform.Rotate(0, Horizontal * rotate * Time.deltaTime, 0);

        Vector3 forward = transform.forward * Vertical * speed * Time.deltaTime;

        cc.Move(forward);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        Jump();
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1)) && isGrounded)
        {
            velocity.y = jumpForce;

            // Play jump sound from assigned AudioSource clip
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Water")
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;

        if (gameOver != null)
            gameOver.SetActive(true);

    }

    IEnumerator RestartAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
