using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float xValue;
    float yValue;
    float zValue;
    [SerializeField] float movementspeed = 0.1f;
    [SerializeField] float Jumpspeed = 0.1f;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip coinSound;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundcheck;
    Rigidbody2D rb;
    int scorecounter = 0;
    int CurrentScene;
    bool isGrounded;
    private Animator animator2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xValue = Input.GetAxisRaw("Horizontal") * movementspeed * Time.deltaTime;
        yValue = Input.GetAxisRaw("Vertical") * Jumpspeed * Time.deltaTime;
        animator2 = GetComponent<Animator>();
        transform.Translate(xValue, yValue, zValue);
        animator.SetFloat("Speed", Mathf.Abs(xValue));
        Flip();
        {
            if
            (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    Jump();
                }
            }


        }


    }
    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("you have collected a coin ");
            scorecounter++;
            Destroy(collision.gameObject);
            audiosource.Play();
            ScoreText.text = "Score :" + scorecounter.ToString();

        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("you died");
            ReloadScene();
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("you collided");
            LoadNextScene();
        }

    }

    void ReloadScene()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }
    void LoadNextScene()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene + 1);

    }
    [SerializeField]
    void Flip()
    {
        if (xValue < 0)
        {
            transform.localScale = new Vector3(-5f, 5f, 5f);
        }
        else if (xValue > 0)
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }
    void Jump()
    {
        rb.velocity = Vector2.up * Jumpspeed;
    }



}
