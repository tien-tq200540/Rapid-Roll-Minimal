using UnityEngine;

public static class SaveSystems
{
    public static void SaveHighScore(long score)
    {
        PlayerPrefs.SetString("HighScore", score.ToString());
    }
    public static long LoadHighScore()
    {
        if (!PlayerPrefs.HasKey("HighScore")) PlayerPrefs.SetString("HighScore", 0.ToString());
        return long.Parse(PlayerPrefs.GetString("HighScore"));
    }
}
