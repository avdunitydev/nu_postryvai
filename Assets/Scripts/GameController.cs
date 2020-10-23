using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform m_StartPanel;
    public Transform m_TopLeftEggsSpawn;
    public Transform m_BottomLeftEggsSpawn;
    public Transform m_TopRightEggsSpawn;
    public Transform m_BottomRightEggsSpawn;

    public GameObject m_EggPrefab;

    public Text m_Title_h1;
    public Text m_Title_h2;
    public Text m_Score;
    public HP m_hp;

    public Button btn_NewGame;
    public Button btn_Continue;
    public Button btn_Exit;

#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [SerializeField]
#endif
    float m_Timer;

#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [SerializeField]
#endif
    bool m_EggIsDone = false;

#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [SerializeField]
#endif
    bool m_IsPausedGame = false;


    void CreateEgg()
    {
        m_EggIsDone = true;

        bool isLeft = GameData.RandomTrueFalse();
        bool isTop = GameData.RandomTrueFalse();
        bool flipIsRight = false;
        GameObject eggInstans;
        Vector3 instansPosition;
        Transform parentPosition;

        if (isLeft)
        {
            if (isTop)
            {
                parentPosition = m_TopLeftEggsSpawn;
                instansPosition = m_TopLeftEggsSpawn.position;
            }
            else
            {
                parentPosition = m_BottomLeftEggsSpawn;
                instansPosition = m_BottomLeftEggsSpawn.position;
            }
        }
        else
        {
            flipIsRight = true;
            if (isTop)
            {
                parentPosition = m_TopRightEggsSpawn;
                instansPosition = m_TopRightEggsSpawn.position;
            }
            else
            {
                parentPosition = m_BottomRightEggsSpawn;
                instansPosition = m_BottomRightEggsSpawn.position;
            }
        }

        eggInstans = GameObject.Instantiate(m_EggPrefab, instansPosition, Quaternion.identity, parentPosition);
        eggInstans.GetComponent<EggController>().m_EggGameObject.GetComponent<SpriteRenderer>().flipX = flipIsRight;
        eggInstans.GetComponent<EggController>().Init(isLeft, isTop, this);

    }


    void PauseGame()
    {
        m_IsPausedGame = true;
        Time.timeScale = 0;
        m_Score.transform.parent.gameObject.SetActive(false);
        m_Title_h2.gameObject.SetActive(false);

        if (GameData.SCORE != 0)
        {
            m_Title_h1.text = "Гра на паузі ... Ну, Постривай!";
            m_Title_h2.text = "Твої БАЛИ : " + GameData.SCORE.ToString();
            m_Title_h2.gameObject.SetActive(true);
            btn_NewGame.gameObject.SetActive(false);
            btn_Continue.gameObject.SetActive(true);
        }

        m_StartPanel.gameObject.SetActive(true);
    }
    void ContinueGame()
    {
        m_IsPausedGame = false;
        m_StartPanel.gameObject.SetActive(false);
        m_Score.transform.parent.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
    void ClearData()
    {
        m_Title_h1.text = "Ну, Постривай !!!";
        GameData.HP = 3;
        GameData.SCORE = 0;
        GameData.SPEED = 3f;
        m_Timer = 3f;
        m_hp.Init();
    }
    void StartNewGame()
    {
        ClearData();
        CreateEgg();
        ContinueGame();
    }
    void GameOver()
    {
        PauseGame();
        m_Title_h1.text = "Гру закінчено ! Незупиняйся спробуй ЩЕ ...";
        btn_NewGame.gameObject.SetActive(true);
        btn_Continue.gameObject.SetActive(false);
        m_StartPanel.gameObject.SetActive(true);
    }

    void ExitGame()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        btn_NewGame.GetComponent<Button>().onClick.AddListener(StartNewGame);
        btn_Continue.GetComponent<Button>().onClick.AddListener(ContinueGame);
        btn_Exit.GetComponent<Button>().onClick.AddListener(ExitGame);

        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.SCORE != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!m_IsPausedGame) PauseGame();
                else ContinueGame();
            }
        }

        if (!m_IsPausedGame)
        {
            m_Timer -= Time.deltaTime;
            if (m_Timer <= 0)
            {
                m_EggIsDone = false;
                m_Timer = 3f;
            }

            if (!m_EggIsDone)
            {
                CreateEgg();
            }

        }

    }

    private void FixedUpdate()
    {
        if (!m_IsPausedGame)
        {
            m_Score.text = GameData.SCORE.ToString();

            if (GameData.HP <= 0)
            {
                GameOver();
            }
        }

    }


}
