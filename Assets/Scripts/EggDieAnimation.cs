using UnityEngine;

public class EggDieAnimation : MonoBehaviour
{
    Transform m_RootEgg;
    AudioSource m_EggCrackAudio;
    public event GameData.my_EventHandler OnEndOfDieAnimationEgg;


    public void EndOfAnimation()
    {
        OnEndOfDieAnimationEgg?.Invoke();

        Destroy(m_RootEgg.gameObject);

    }

    public void SoundEffectEggCrack()
    {
        m_EggCrackAudio.Play();
    }

    public void PlayAnimation()
    {
        if (m_RootEgg.GetComponent<EggController>().m_IsLeft) GetComponent<Animator>().Play("dieLeft");
        else GetComponent<Animator>().Play("dieRight");
        SoundEffectEggCrack();
    }

    private void Start()
    {
        m_RootEgg = transform.parent.transform.parent;
        m_EggCrackAudio = GetComponent<AudioSource>();
        m_RootEgg.GetComponentInChildren<Egg>().OnEggIsBroke += PlayAnimation;
    }


}
