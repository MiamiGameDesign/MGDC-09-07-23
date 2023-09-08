using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    public CharacterMove characterMove;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platforms")
        {
            characterMove.canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            characterMove.canJump = false;
        }
    }
}