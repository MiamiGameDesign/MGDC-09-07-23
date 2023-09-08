using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [Header("Vectors")]
    public Vector2 mousePosition;
    public Vector2 direction;
    public Vector2 startPosition;
    public Vector2 hitStartPosition;

    [Header("GameObjects and Components")]
    public LayerMask platformLayerMask;
    public Rigidbody2D rb;
    public DistanceJoint2D distanceJoint;
    public GameObject reticle;
    public CharacterMove characterMove;
    public LineRenderer lineRenderer;

    [Header("Variables")]
    private float maxRopeLength = 10;
    private float pullSpeed = 0.01f;
    private float startDistance;
    public bool isGrappled = false;
    RaycastHit2D hit;

    // Update is called once per frame
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
        if (Input.GetMouseButtonDown(0))
        {
            GrappleToObject();
        }

        if(isGrappled && distanceJoint.distance <= startDistance)
        {
            distanceJoint.distance -= pullSpeed * Input.GetAxisRaw("Vertical");
        }

        if(distanceJoint.distance > startDistance)
        {
            distanceJoint.distance = distanceJoint.distance -= 0.01f;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            resetHook();
        }

        if(distanceJoint.enabled == false)
        {
            lineRenderer.SetPosition(1, transform.position);
        }

        if (startPosition.y > hitStartPosition.y)
        {
            if (transform.position.y > hitStartPosition.y)
            {
                distanceJoint.distance -= pullSpeed * 2;
            }
        }
    }

    void GrappleToObject()
    {
        if (hit)
        {
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

            if(characterMove.canJump == false)
            {
                rb.velocity = new Vector2(rb.velocity.x * 1.5f, (rb.velocity.y * 2) + 5);
            }
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
}