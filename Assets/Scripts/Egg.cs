using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    Rigidbody2D m_EggBody;

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "plane")
        {
            Invoke("EggCrash", .3f);
        }

    }

    void EggCrash()
    {
        gameObject.SetActive(false);
        transform.parent.GetComponent<EggController>().EggRemove();
    }

    private void Start()
    {
        m_EggBody = GetComponent<Rigidbody2D>();
        m_EggBody.drag = GameData.LINER_DRAG;
    }
}
