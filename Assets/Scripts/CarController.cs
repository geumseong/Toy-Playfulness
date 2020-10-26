using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    private static CarController _instance;
    public static CarController Instance
    {
        get { return _instance; }
    }
    public bool isInInteractableRange;
    public MiniGame currentMinigame;

    SpriteRenderer spriteRenderer;
    [SerializeField] float accelerationPower = 5f;
    [SerializeField] float steeringPower = 5f;
    float steeringAmount;
    float moveSpeed;
    float direction;

    private Rigidbody2D rb;
    private bool canSteer;

    void Awake()
    {
        if (!Instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);


            rb = gameObject.GetComponent<Rigidbody2D>();

            canSteer = true;
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log(Instance);
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += HideOutsideOfMainScene;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= HideOutsideOfMainScene;
        Debug.Log("Disabled");
    }

    private void HideOutsideOfMainScene(Scene scene1, Scene scene2)
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (scene2.name != "Main")
        {
            spriteRenderer.enabled = false;
            canSteer = false;
        }
        else
        {
            spriteRenderer.enabled = true;
            canSteer = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInInteractableRange)
        {
            if (currentMinigame != null)
            {
                currentMinigame.Run();
            }
        }
    }

    private void FixedUpdate()
    {
        if (canSteer)
        {
            steeringAmount = -Input.GetAxis("Horizontal");
            moveSpeed = Input.GetAxis("Vertical") * accelerationPower;
            direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
            rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

            rb.AddRelativeForce(Vector2.up * moveSpeed);

            rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
        }
    }

    public void SetOnTrigger(bool isInInteractableRange, MiniGame currentMinigame)
    {
        this.isInInteractableRange = isInInteractableRange;
        this.currentMinigame = currentMinigame;
    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}
