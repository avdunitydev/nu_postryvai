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
    public Text m_Title_h3;
    public Text m_Score;
    public HP m_hp;

    public Button btn_NewGame;
    public Button btn_Continue;
    public Button btn_Exit;
    public Button[] btns_InputMobile;

    public bool m_IsPausedGame = false;
    public event GameData.my_EventHandler OnSpeedUp;

#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [SerializeField]
#endif
    float m_GlobalTimer;
    float m_Timer;
    int m_BestScore;



    void CreateEgg()
    {

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
        eggInstans.tag = "egg";
        eggInstans.GetComponent<EggController>().m_EggGameObject.GetComponent<SpriteRenderer>().flipX = flipIsRight;
        eggInstans.GetComponent<EggController>().Init(isLeft, isTop, this);
        eggInstans.GetComponent<EggController>().m_EggGameObject.GetComponent<Egg>().OnEggIsBroke += HitEggIsBroke;
        eggInstans.GetComponent<EggController>().m_AnimDie.GetComponent<EggDieAnimation>().OnEndOfDieAnimationEgg += HitEndAnimationEggIsBroke;

    }

    private void HitEndAnimationEggIsBroke()
    {
        if (GameData.HP <= 0)
        {
            GameData.GAME_IS_RUN = false;
            GameOver();
        }
    }

    void HitEggIsBroke()
    {
        m_hp.RemoveLife();
    }

    void PauseGame()
    {
        m_BestScore =  (m_BestScore > GameData.SCORE) ? m_BestScore : GameData.SCORE;
        m_IsPausedGame = true;
        Time.timeScale = 0;
        m_Score.transform.parent.gameObject.SetActive(false);
        m_Title_h2.gameObject.SetActive(false);
        m_Title_h3.gameObject.SetActive(false);

        if (GameData.SCORE != 0)
        {
            m_Title_h1.text = "Гра на паузі ... Ну, Постривай!";
            m_Title_h2.text = "Твої БАЛИ : " + GameData.SCORE.ToString();
            m_Title_h3.text = $"Рекорд Гри: [{m_BestScore}]";
            m_Title_h2.gameObject.SetActive(true);
            m_Title_h3.gameObject.SetActive(true);
            btn_NewGame.gameObject.SetActive(false);
            btn_Continue.gameObject.SetActive(true);
        }

        m_StartPanel.gameObject.SetActive(true);
    }
    public void ContinueGame()
    {
        GameData.GAME_IS_RUN = true;
        m_StartPanel.gameObject.SetActive(false);
        m_Score.transform.parent.gameObject.SetActive(true);
        m_IsPausedGame = false;
        Time.timeScale = 1;
    }
    void ClearData()
    {
        m_Title_h1.text = "Ну, Постривай !!!";
        GameData.HP = 4;
        GameData.SCORE = 0;
        GameData.SPEED = 2f;
        GameData.LINER_DRAG = 10f;
        m_GlobalTimer = 0f;
        ClearTimer();
        m_hp.Init();
    }
    public void StartNewGame()
    {
        ClearData();
        GameData.GAME_IS_RUN = true;
        CreateEgg();
        ContinueGame();
    }
    void GameOver()
    {
        PauseGame();
        RemoveEggsInScene();
        m_Title_h1.text = "Гру закінчено ! Незупиняйся спробуй ЩЕ ...";
        btn_NewGame.gameObject.SetActive(true);
        btn_Continue.gameObject.SetActive(false);
        m_StartPanel.gameObject.SetActive(true);
    }

    private void RemoveEggsInScene()
    {
        GameObject[] availableEggs = GameObject.FindGameObjectsWithTag("egg");
        foreach (var item in availableEggs)
        {
            Destroy(item);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    void ActivateButtonIsMobile()
    {
        foreach (var item in btns_InputMobile)
        {
            item.gameObject.SetActive(GameData.IsMobile());
        }

    }

    void ClearTimer()
    {
        m_Timer = 10f;
    }

    private void SpeedUpLevel()
    {
        if (!m_IsPausedGame)
        {
            m_GlobalTimer += Time.deltaTime;
            if (m_GlobalTimer >= 10)
            {
                OnSpeedUp?.Invoke();
                ++GameData.SPEED;
                if (GameData.LINER_DRAG > 0) --GameData.LINER_DRAG;
                m_GlobalTimer = 0f;
            }
        }
    }


    private void Awake()
    {
        m_BestScore = PlayerPrefs.GetInt("best_score");
    }

    // Start is called before the first frame update
    void Start()
    {
        btn_NewGame.gameObject.SetActive(true);
        btn_Continue.gameObject.SetActive(false);
        m_hp.GetComponents<HP>();
        PauseGame();
        ActivateButtonIsMobile();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.GAME_IS_RUN)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!m_IsPausedGame) PauseGame();
                else ContinueGame();
            }
        }

        SpeedUpLevel();

        if (!m_IsPausedGame)
        {
            m_Timer -= Time.deltaTime * GameData.SPEED;
            if (m_Timer <= 0)
            {
                CreateEgg();
                ClearTimer();
            }

            m_Score.text = GameData.SCORE.ToString();

        }

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("best_score", m_BestScore);
    }
}
