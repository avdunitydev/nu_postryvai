using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int m_HPColst = 5;
    public Sprite m_HPSprite;

    Vector3 m_PositionOffset = new Vector3(0, 0, 0);
    Vector3 m_SpriteScale = new Vector3(.5f, .5f, 1);

    private void Start()
    {
        for (int i = 0; i < m_HPColst; i++)
        {
            GameObject hp = new GameObject("HP" + i);
            hp.AddComponent<SpriteRenderer>().sprite = m_HPSprite;
            hp.transform.localScale = m_SpriteScale;
            hp.transform.position = transform.position + m_PositionOffset;
            hp.transform.SetParent(transform);

            m_PositionOffset += new Vector3(.5f, 0, 0);
        }
    }


}
