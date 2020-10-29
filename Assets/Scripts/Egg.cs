using UnityEngine;

public class Egg : MonoBehaviour
{
    bool m_IsFirstDrop = true;
    Rigidbody2D m_EggBody;
    public event GameData.my_EventHandler OnEggIsBroke;


    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "plane" && m_IsFirstDrop)
        {
            m_IsFirstDrop = false;            
            Invoke("EggCrash", .3f);
        }

    }

    void EggCrash()
    {
        OnEggIsBroke?.Invoke();
        gameObject.SetActive(false);

    }

    private void Start()
    {
        m_EggBody = GetComponent<Rigidbody2D>();
        m_EggBody.drag = GameData.LINER_DRAG;
    }

}
