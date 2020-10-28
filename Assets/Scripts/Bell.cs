using UnityEngine;

public class Bell : MonoBehaviour
{
    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.OnSpeedUp += UpLevel;
    }

    private void UpLevel()
    {
        GetComponent<Animator>().Play("bell");
        GetComponent<AudioSource>().Play();
    }

}
