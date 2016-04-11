using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    private float movementSpeed = 10f; 
    private float jumpHeight = 7f; 
    bool canJump = true; 
    private Rigidbody rb;
  
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(move * movementSpeed);

        if (canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(0.0f, jumpHeight, 0.0f);
                canJump = false;
            }
        }

        if (rb.velocity.magnitude < movementSpeed)
        {
            rb.AddForce(move * movementSpeed);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }

    /*void OnCollisionEnter(Collision other)  //Used to detect Enemies who collide with the player
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }

        else if(other.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }*/
}

/*
    public GameObject[] Coll;   //All the collectables in the level
    public GameObject deathParticals;
    public Text winText;

    int maxScore;
    int currentScore;          //Number of collectables
    Vector3 spawn;              //Spawn points
    Vector2 movement;           //Used for moving the player
    float maxSpeed = 10;
    int currentLevel;

    void Awake()
    {
        currentLevel = LevelController.currentLevel;
        winText.text = "";
        maxScore = Coll.Length;
        currentScore = maxScore;
        spawn = transform.position;                     //Spawn point
       
        movement = new Vector2(h, v);

        if(playerRigidbody.position.y <= -25f)
        {
            Die();
        }

        if (currentLevel >= 4)
        {
            winText.text = "You Win!!!";
        }
    }

    void Die()//Death and set to spawn point
    {
        Instantiate(deathParticals, transform.position, Quaternion.identity);
        transform.position = spawn;
        ResetCollect();
        currentScore = maxScore;
    }

    void OnTriggerEnter(Collider other) //Used to see of what the player has triggered an object
    {
        if (other.gameObject.CompareTag("Collect"))//Collecting object
        {
            other.gameObject.SetActive(false);
            currentScore -= 1;

        }

        if (other.transform.tag == ("Goal") && currentScore <= 0)//Goal trigger
        {
            LevelController.CompleteLevel();
        } 
    }

    void OnCollisionEnter(Collision other)  //Used to detect Enemies who collide with the player
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }

        else if(other.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }

    void ResetCollect()//Resetting the collectables to active
    {
        for(int i = 0; i < Coll.Length ; i++)
        {
            Coll[i].SetActive(true);
        }
    }
}*/

/*
    public Text countText;
    public Text winText;
    private int count;

    void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 30)
        {
            winText.text = "You Win!";
        }
    }
}*/
