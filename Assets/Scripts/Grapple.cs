using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grapple : MonoBehaviour
{
    [Header("Vectors")]
    public Vector2 mousePosition;
    public Vector2 direction;
    public Vector2 startPosition;
    public Vector2 hitStartPosition;
    private Vector3 lastPosition = Vector3.zero;

    [Header("GameObjects and Components")]
    public LayerMask platformLayerMask;
    public Rigidbody2D rb;
    public DistanceJoint2D distanceJoint;
    public GameObject reticle;
    public LineRenderer lineRenderer;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public MeshRenderer meshRenderer;

    [Header("Variables")]
    private float maxRopeLength = 10;
    private float pullSpeed = 5;
    private float startDistance;
    private float speed;
    public bool isGrappled = false;
    RaycastHit2D hit;

    public AudioSource audioSource;
    public AudioClip[] meow;
    public AudioClip shoot;
    public AudioClip reel;
    public AudioClip die;
    public AudioClip win;

    void Start()
    {
        rb.gravityScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {   
        //Single line updates
        lineRenderer.SetPosition(0, transform.position);
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        direction = (mousePosition - new Vector2(transform.position.x, transform.position.y));
        hit = Physics2D.Raycast(transform.position, direction, maxRopeLength, platformLayerMask);

        //Functions
        CheckReticlePosition();

        //If statements
        if (Input.GetMouseButtonDown(0) && gameOverScreen.activeInHierarchy == false)
        {
            GrappleToObject();
        }

        if(isGrappled && distanceJoint.distance <= startDistance && gameOverScreen.activeInHierarchy == false)
        {
            distanceJoint.distance -= pullSpeed * Time.deltaTime;
        }

        if(distanceJoint.distance > startDistance && gameOverScreen.activeInHierarchy == false)
        {
            distanceJoint.distance = distanceJoint.distance -= 0.01f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && gameOverScreen.activeInHierarchy == false)
        {
            resetHook();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(distanceJoint.enabled == false && gameOverScreen.activeInHierarchy == false)
        {
            lineRenderer.SetPosition(1, transform.position);
        }

        if(transform.position.x >= 52)
        {
            gameWinScreen.SetActive(true);
            reticle.SetActive(false);
            meshRenderer.enabled = false;
            lineRenderer.enabled = false;
            audioSource.PlayOneShot(win, 5);
        }
    }

    private void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

    void GrappleToObject()
    {
        if (hit)
        {
            audioSource.PlayOneShot(meow[Random.Range(0, meow.Length)]);
            audioSource.PlayOneShot(shoot);
            distanceJoint.enabled = true;
            distanceJoint.connectedAnchor = hit.point;
            isGrappled = true;
            startDistance = distanceJoint.distance;
            startPosition = transform.position;
            hitStartPosition = hit.point;

            lineRenderer.SetPosition(1, hit.point);
        }
    }

    void resetHook()
    {
        if(distanceJoint.enabled == true)
        {
            distanceJoint.enabled = false;
            isGrappled = false;
        }
    }

    void CheckReticlePosition()
    {
        if(Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)) < maxRopeLength)
        {
            if(hit == false)
            {
                reticle.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
            }
            else
            {
                if(Mathf.Sqrt(Mathf.Pow(hit.point.x - transform.position.x, 2) + Mathf.Pow(hit.point.y - transform.position.y, 2)) > Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)))
                {
                    reticle.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
                }
                else
                {
                    reticle.transform.position = new Vector3(hit.point.x, hit.point.y, -1);
                }
            }
        }
        else
        {
            if(hit == false)
            {
                reticle.transform.position = new Vector3(transform.position.x + (direction.normalized.x * maxRopeLength), transform.position.y + (direction.normalized.y * maxRopeLength), -1);
            }
            else
            {
                reticle.transform.position = new Vector3(hit.point.x, hit.point.y, -1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Airlock") || speed >= 0.15f)
        {
            gameOverScreen.SetActive(true);
            reticle.SetActive(false);
            meshRenderer.enabled = false;
            lineRenderer.enabled = false;
            audioSource.PlayOneShot(die);
        }
    }
}