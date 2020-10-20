public static class GameData
{
    public static int HP = 1;
    public static int SCORE = 0;
    public static float SPEED = 3f;

    public static bool RandomTrueFalse() => (UnityEngine.Random.Range(-1.0f, 1.0f) >= 0) ? true : false;

}