using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 dir;

    [SerializeField] private int speed;
    [SerializeField] float JumpForce;
    [SerializeField] float gravity;
    [SerializeField] GameObject losePanel;
    [SerializeField] Text coinText;
    [SerializeField] Score scoreScript;
    [SerializeField] GameObject car;

    private bool underShield = false;

    [SerializeField] private int Coins = 0;

    [SerializeField] private int MaxSpeed = 120;
    
    private int lineToMove = 1;
    public float lineDistance = 3;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Coins = PlayerPrefs.GetInt("coins");
        coinText.text = Coins.ToString();
        StartCoroutine(SpeedIncrease());
    }

    public void Update()
    {
        if (SwipeController.swipeRight)
        {
            if(lineToMove < 2)
                lineToMove++;
        }
        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }
        if (SwipeController.swipeUp)
        {
            if(controller.isGrounded)
                Jump();
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
            
        Vector3 diff = targetPosition - transform.position;
        Vector3 movedir = diff.normalized * 25 * Time.deltaTime;
        if (movedir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(movedir);
        else
            controller.Move(diff);
    }

    private void Jump()
    {
        dir.y = JumpForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir.y += gravity * Time.fixedDeltaTime;
        dir.z = speed;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "obstacle")
        {
            if (underShield)
            {
                Destroy(hit.gameObject);
                underShield = false;
                
            }
            else
            {
                losePanel.SetActive(true);
                int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
                PlayerPrefs.SetInt("lastRunScore", lastRunScore);
                GetComponent<AudioSource>().Pause();
                Time.timeScale = 0f;
            }
        }

        /*if (hit.transform.CompareTag("springBoard"))
            StartCoroutine(CarRotate());*/
            

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coins++;
            coinText.text = Coins.ToString();
            PlayerPrefs.SetInt("coins", Coins);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BonusStar")
        {
            StartCoroutine(BonusStar());
            Debug.Log(scoreScript.plusScore);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Shield")
        {
            StartCoroutine(BonusShield());
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "springBoard")
        {
            Jump();
        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(3);
        
        if(speed <= MaxSpeed)
        {
            speed += 3;
            StartCoroutine(SpeedIncrease()); 
        }
                   
    }

    private IEnumerator BonusStar()
    {
        scoreScript.plusScore = 2;

        yield return new WaitForSeconds(5);

        scoreScript.plusScore = 1;
    }

    private IEnumerator BonusShield()
    {
        underShield = true;

        yield return new WaitForSeconds(5);

        underShield = false;
    }

    private IEnumerator CarRotate()
    {
        car.transform.Rotate(0f, 0f, 0.45f);
        yield return new WaitForSeconds(1);
        car.transform.Rotate(0f, 0f, -0.45f);
    }
}
