using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUnpause : MonoBehaviour
{
    public bool isTimeFrozen; 
    public void FreezeTime()
    {
        Time.timeScale = 0;
        isTimeFrozen = true;
    }
    public void UnfreezeTime()
    {
        Time.timeScale = 1;
        isTimeFrozen = false;
    }
}
