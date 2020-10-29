using UnityEngine;
using UnityEngine.UI;

public class MusicSwitcher : MonoBehaviour
{
    public Sprite[] m_SoundIcons;
    public AudioSource m_MusicBG;

    Image m_SoundImage;

    GameData.enum_MusicMode m_Mode;

    public void onClickSwitcher()
    {
        ++m_Mode;
        if ((int)m_Mode > 2)
        {
            m_Mode = 0;
        }

        switch (m_Mode)
        {
            case GameData.enum_MusicMode.mute:
                m_MusicBG.volume = 0f;
                m_MusicBG.Pause();
                m_SoundImage.sprite = m_SoundIcons[0];
                break;
            case GameData.enum_MusicMode.silentMode:
                m_MusicBG.volume = 0.4f;
                m_MusicBG.UnPause();
                m_SoundImage.sprite = m_SoundIcons[1];
                break;
            case GameData.enum_MusicMode.loudMode:
                m_MusicBG.volume = 1f;
                m_MusicBG.UnPause();
                m_SoundImage.sprite = m_SoundIcons[2];
                break;
            default:
                m_MusicBG.volume = 1f;
                m_MusicBG.Play();
                m_SoundImage.sprite = m_SoundIcons[2];
                break;
        }
    }

    void Start()
    {
        m_Mode = GameData.enum_MusicMode.loudMode;
        m_SoundImage = GetComponent<Image>();
        m_SoundImage.sprite = m_SoundIcons[2];
    }

}
