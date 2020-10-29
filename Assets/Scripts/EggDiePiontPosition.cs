using UnityEngine;

public class EggDiePiontPosition : MonoBehaviour
{
    bool isLeft;
    private void Start()
    {
        isLeft = transform.parent.GetComponent<EggController>().m_IsLeft;
        if (isLeft) transform.position = new Vector3(-3.3f, -3f, 0);
        else transform.position = new Vector3(3.3f, -3f, 0);
    }

}
