using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SceneSelectScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform snapPt;

    GameObject closestCard;

    public enum state
    {
        moving,
        locked,
        locking
    }

    state cardState = state.locked;
         
    void Awake()
    {
        closestCard = GameObject.Find("Card");
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cardState = state.moving;
        }
        if (Mathf.Abs(scrollRect.velocity.x) == 0&& Input.GetMouseButtonUp(0))
        {
            cardState = state.locked;
        }

        if (Mathf.Abs(scrollRect.velocity.x) < 20 && cardState == state.moving)
        {
            float dist = 500f;
            cardState = state.locking;

            foreach (GameObject card in GameObject.FindGameObjectsWithTag("SceneCard"))
            {
                float cardDist = Mathf.Abs(card.transform.position.x - snapPt.transform.position.x);

                if (cardDist < dist)
                {
                    dist = cardDist;
                    closestCard = card;
                }
            }
        }

        if (cardState == state.locking)
        {
            scrollRect.velocity = new Vector2(snapPt.transform.position.x - closestCard.transform.position.x, 0);
        }
    }
}
