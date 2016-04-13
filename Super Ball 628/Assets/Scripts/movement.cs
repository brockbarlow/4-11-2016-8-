using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    public GameObject[] Collects;
    private float movementSpeed = 10f; 
    private float jumpHeight = 9f; 
    bool canJump = true; 
    private Rigidbody rb;
    Vector3 respawnPoint;
    private int maxItems; 
    private int currentItems;
    public Text currentText;
    public Text doorText;
  
	void Start () {
        currentItems = 0;
        setCurrentText();
        setDoorText();
        maxItems = Collects.Length;
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
	}

	void Update () {
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

        if (other.gameObject.CompareTag("Respawner"))
        {
            resetCollects();
            resetPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            currentItems++;
            setCurrentText();

            if (currentItems == maxItems)
            {
                doorText.text = "The door opens...";
            }
        }

        if (other.gameObject.CompareTag("Door"))
        {
            if (currentItems != maxItems)
            {
                doorText.text = "You're not ready...";
            }

            if (currentItems == maxItems)
            {
                levelLoader.nextLevel();
            }
        }
    }

    void setCurrentText()
    {
        currentText.text = "Count: " + currentItems.ToString();
    }

    void setDoorText()
    {
        doorText.text = "The door lies shut...";
    }

    void resetCollects()
    {
        for (int i = 0; i < Collects.Length; i++)
        {
            Collects[i].SetActive(true);
        }
    }

    void resetPlayer()
    {
        currentItems = 0;
        currentText.text = "Count: " + currentItems.ToString();
        doorText.text = "The door lies shut...";
        transform.position = respawnPoint;
    }
}