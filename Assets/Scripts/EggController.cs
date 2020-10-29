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

    // Start is called before the first frame update
    void Start()
    {
        m_EggGameObject.SetActive(true);
    }


}
