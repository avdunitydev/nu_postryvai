using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform m_StartPanel;
    public Transform m_TopLeftEggsSpawn;
    public Transform m_BottomLeftEggsSpawn;
    public Transform m_TopRightEggsSpawn;
    public Transform m_BottomRightEggsSpawn;

    public GameObject m_LeftEgg;
    public GameObject m_RightEgg;

    public Text m_Score;
    public HP m_hp;

    public Button btn_NewGame;


    float m_Timer;
    bool m_EggIsDone = false;
    bool m_IsPaused = false;


    void CreateEgg()
    {
        m_EggIsDone = true;

        bool isLeft = GameData.RandomTrueFalse();
        bool isTop = GameData.RandomTrueFalse();

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


            eggInstans = GameObject.Instantiate(m_LeftEgg, instansPosition, Quaternion.identity, parentPosition);

        }
        else
        {
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

            eggInstans = GameObject.Instantiate(m_RightEgg, instansPosition, Quaternion.identity, parentPosition);

        }

        eggInstans.GetComponent<Egg>().Init(isLeft, isTop, this);

    }


    void PauseGame()
    {
        Time.timeScale = 0;
        m_IsPaused = true;
        m_StartPanel.gameObject.SetActive(true);
    }
    void ContinueGame()
    {
        Time.timeScale = 1;
        m_IsPaused = false;
        m_StartPanel.gameObject.SetActive(false);
        m_Timer = 3f;

    }
    void ClearData()
    {
        GameData.HP = 3;
        GameData.SCORE = 0;
        GameData.SPEED = 3f;
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
    }


    // Start is called before the first frame update
    void Start()
    {

        btn_NewGame.GetComponent<Button>().onClick.AddListener(StartNewGame);

        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // OnApplicationPause();
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameData.SCORE != 0)
        {
            if (m_IsPaused) ContinueGame();
            else PauseGame();
        }

        if (!m_IsPaused)
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
        m_Score.text = GameData.SCORE.ToString();

        if (GameData.HP <= 0)
        {
            GameOver();
        }


    }


}
