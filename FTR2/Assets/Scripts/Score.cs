using UnityEngine;
public class Score : MonoBehaviour
{
    static public float score = 0;

    public void addScore()
    {
        score += 1;
    }
}
