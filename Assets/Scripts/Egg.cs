using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
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


}
