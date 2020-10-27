using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDieAnimation : MonoBehaviour
{
    Transform m_RootEgg;
    AudioSource m_EggCrackAudio;

    public void EndOfAnimation()
    {        
        Destroy(m_RootEgg.gameObject);

        if (GameData.HP <= 0)
        {
            GameData.GAME_IS_RUN = false;
        }
    }

    public void SoundEffectEggCrack(){
        m_EggCrackAudio.Play();
    }

    private void Start()
    {
        m_RootEgg = transform.parent.transform.parent;
        m_EggCrackAudio = GetComponent<AudioSource>();
    }


}
