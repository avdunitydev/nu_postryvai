using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public GameObject m_EggGameObject;
    public GameObject m_AnimDie;
    public bool m_IsLeft { get; private set; }
    public bool m_IsTop { get; private set; }

    GameController m_Controller;

    public void Init(bool isLeft, bool isTop, GameController controller)
    {
        m_Controller = controller;
        m_IsLeft = isLeft;
        m_IsTop = isTop;       
    }

    public void EggRemove()
    {
        m_Controller.m_hp.RemoveLife();

        m_AnimDie.transform.parent.gameObject.SetActive(true);
        if (m_IsLeft) m_AnimDie.GetComponent<Animator>().Play("dieLeft");
        else m_AnimDie.GetComponent<Animator>().Play("dieRight");
    }


    // Start is called before the first frame update
    void Start()
    {
        m_EggGameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
