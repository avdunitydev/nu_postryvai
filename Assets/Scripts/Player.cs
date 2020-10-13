using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] m_Sprites;

    [SerializeField]
    bool m_IsTop;

    [SerializeField]
    bool m_IsLeft;

    SpriteRenderer m_CurrentSprite;
    CircleCollider2D m_BasketCollider;

    void SetPositionTopLeft()
    {
        m_IsTop = true;
        m_IsLeft = true;
        transform.localPosition = new Vector3(-2.3f, 0, 0);
        m_CurrentSprite.sprite = m_Sprites[0];
        m_BasketCollider.offset = new Vector2(-1, 1.5f);
    }

    void SetPositionTopRight()
    {
        m_IsTop = true;
        m_IsLeft = false;
        transform.localPosition = new Vector3(2.3f, 0, 0);
        m_CurrentSprite.sprite = m_Sprites[1];
        m_BasketCollider.offset = new Vector2(1, 1.5f);
    }

    void SetPositionBottomLeft()
    {
        m_IsTop = false;
        m_IsLeft = true;
        transform.localPosition = new Vector3(-2.3f, 0, 0);
        m_CurrentSprite.sprite = m_Sprites[2];
        m_BasketCollider.offset = new Vector2(-1, 0);
    }

    void SetPositionBottomRight()
    {
        m_IsTop = false;
        m_IsLeft = false;
        transform.localPosition = new Vector3(2.3f, 0, 0);
        m_CurrentSprite.sprite = m_Sprites[3];
        m_BasketCollider.offset = new Vector2(1, 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        m_CurrentSprite = GetComponent<SpriteRenderer>();
        m_BasketCollider = GetComponent<CircleCollider2D>();
        SetPositionTopLeft();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (m_IsLeft)
            {
                SetPositionTopLeft();
            }
            else
            {
                SetPositionTopRight();
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_IsLeft)
            {
                SetPositionBottomLeft();
            }
            else
            {
                SetPositionBottomRight();
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (m_IsTop)
            {
                SetPositionTopLeft();
            }
            else
            {
                SetPositionBottomLeft();
            }


        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (m_IsTop)
            {
                SetPositionTopRight();
            }
            else
            {
                SetPositionBottomRight();
            }


        }



    }


}
