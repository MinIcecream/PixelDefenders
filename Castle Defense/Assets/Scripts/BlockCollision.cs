using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public BoxCollider2D charColl;
    public BoxCollider2D charBlockerColl;

    void Start()
    {
        Physics2D.IgnoreCollision(charColl, charBlockerColl, true);
    }
}
