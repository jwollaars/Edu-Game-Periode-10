using UnityEngine;
using System.Collections;

public class ProgressInfo
{
    public int Score;
    public int Mistakes;

    public ProgressInfo()
    {
        Score = 0;
        Mistakes = 0;
    }

    public void AddScore()
    {
        Score++;
    }

    public void RemoveScore()
    {
        Score--;
        Mistakes++;
    }
}
