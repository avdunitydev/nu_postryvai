using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlatform : MonoBehaviour
{
    Camera m_Camera;
    Image m_FrameImage;

    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Image>(out m_FrameImage))
        {
            if (!GameData.IsMobile()) m_FrameImage.gameObject.SetActive(false);
        }

        float camSize = (GameData.IsMobile()) ? 5.1f : 3.9f;
        Vector3 camPosition = (GameData.IsMobile()) ? new Vector3(0f,-0.95f, -10f) : new Vector3(0f, 0f, -10f);

        if (TryGetComponent<Camera>(out m_Camera))
        {
            m_Camera.orthographicSize = camSize;
            m_Camera.transform.position = camPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
