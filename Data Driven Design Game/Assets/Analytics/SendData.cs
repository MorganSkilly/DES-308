using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEditor;

public class SendData : MonoBehaviour
{
	
	string pathprefix = Application.streamingAssetsPath + "/AnalyticsData";
	//string pathprefix = "Assets/StreamingAssets/AnalyticsData";
	
	public void Send()
	{
		Debug.Log(SystemInfo.deviceUniqueIdentifier);
		string user = SystemInfo.deviceUniqueIdentifier.ToString();
		
		Task.Factory.StartNew(() => Discord.SendFile(
			user,
			"Level 1 deaths.csv",
			"csv",
			pathprefix + "/Level 1 deaths.txt",
			"application/msexcel",
			"Lvl-1 Death Data",
			"https://discordapp.com/api/webhooks/767362643455377408/oaZPDUpITeSHH-p75uaeuEFs3iP3bhJ_mzq-kQ2K49NTImq7GC4HwtiZgLUC5XpXOd_v"));
			
		Task.Factory.StartNew(() => Discord.SendFile(
			user,
			"Level 1 gems.csv",
			"csv",
			pathprefix + "/Level 1 gems.txt",
			"application/msexcel",
			"Lvl-1 Gem Data",
			"https://discordapp.com/api/webhooks/773009375538577409/Xx1EiOXCK7_Gn-g0814rcrs-v9X2hV8bSXjqwQSdrNSZy7ZQ25jnOBjaSUqwBVLdsdAp"));
	    
#if UNITY_STANDALONE
		System.Threading.Thread.Sleep(3000);
		Application.Quit();
#endif
    }
}
