using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePiontPosition : MonoBehaviour
{
    bool isLeft;

    // Start is called before the first frame update
    void Start()
    {
        isLeft = transform.parent.GetComponent<EggController>().m_IsLeft;
        if (isLeft) transform.position = new Vector3(-3.3f, -3f, 0);
        else transform.position = new Vector3(3.3f, -3f, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
