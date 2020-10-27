public static class GameData
{
    public static int HP = 0;
    public static int SCORE = 0;
    public static float SPEED = 0f;
    public static float LINER_DRAG = 0f;
    public static bool GAME_IS_RUN = false;

    public enum enum_MusicMode
    {
        mute,
        silentMode,
        loudMode
    }

    public static bool RandomTrueFalse() => (UnityEngine.Random.Range(-1.0f, 1.0f) >= 0) ? true : false;
    public static bool IsMobile() => (UnityEngine.Application.isMobilePlatform) ? true : false;


}