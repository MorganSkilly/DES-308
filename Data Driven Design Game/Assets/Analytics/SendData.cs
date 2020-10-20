using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendData : MonoBehaviour
{
    public void Send()
    {
        Discord.SendFile(
            "Level 1 death data file",
            "Level 1 deaths.csv",
            "csv",
            "Assets/Analytics/Data/Level 1 deaths.txt",
            "application/msexcel",
            "Lvl-1 Death Data",
            "https://discordapp.com/api/webhooks/767362643455377408/oaZPDUpITeSHH-p75uaeuEFs3iP3bhJ_mzq-kQ2K49NTImq7GC4HwtiZgLUC5XpXOd_v");

        Application.Quit();
    }
}
