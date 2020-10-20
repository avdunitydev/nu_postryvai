using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool m_IsLeft;
    public bool m_IsTop;

    GameController m_Controller;

    public void Init(bool isLeft, bool isTop, GameController controller)
    {
        m_Controller = controller;
        m_IsLeft = isLeft;
        m_IsTop = isTop;
        gameObject.tag = "egg";

    }



    void EggCrashed()
    {
        m_Controller.m_hp.RemoveLife();
        Destroy(gameObject);
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "plane")
        {
            Invoke("EggCrashed", 0.35f);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
