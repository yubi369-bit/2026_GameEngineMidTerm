using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public static class HighScore
{


    private const string KEY = "HighScore";


    public static int Load(int stage)
    {
        return PlayerPrefs.GetInt(KEY + stage, 0);
    }




    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Load(stage))
            return;

        PlayerPrefs.SetInt(KEY + stage, newScore);
        PlayerPrefs.Save();

    }
}


public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    float score;





    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0f;

    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * MoveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnMove(InputValue Value)
    {
        Vector2 input = Value.Get<Vector2>();
        moveInput = input.x;
    }

    public void OnJump(InputValue Value)
    {
        if (Value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.CompareTag("Finish"))
        {
            //HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
            StageResultSaver.SaveStage(SceneManager.GetActiveScene().buildIndex, (int)score);

        }
    }



}
