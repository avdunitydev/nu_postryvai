using System.Collections;
using UnityEngine;

public class HP : MonoBehaviour
{
    public Sprite m_HPSprite;

    ArrayList m_Lifes = new ArrayList();

    Vector3 m_PositionOffset = Vector3.zero;
    Vector3 m_SpriteScale = new Vector3(.5f, .5f, 1);

    public void Init()
    {

        for (int i = 0; i < GameData.HP; i++)
        {
            GameObject hp = new GameObject("HP" + i);
            hp.AddComponent<SpriteRenderer>().sprite = m_HPSprite;
            hp.transform.localScale = m_SpriteScale;
            hp.transform.position = transform.position + m_PositionOffset;
            hp.transform.SetParent(transform);
            m_Lifes.Add(hp);

            m_PositionOffset += new Vector3(.5f, 0, 0);
        }

        m_PositionOffset = Vector3.zero;
    }

    public void RemoveLife()
    {
        --GameData.HP;
        int lastIndex = m_Lifes.Count - 1;
        Destroy(m_Lifes[lastIndex] as GameObject);

        m_Lifes.RemoveAt(lastIndex);
    }

   
}
