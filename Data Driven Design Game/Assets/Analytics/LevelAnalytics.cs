using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelAnalytics : MonoBehaviour
{
	[SerializeField]
	int gems = 0;
	[SerializeField]
	int deaths = 0;
	[SerializeField]
	int kills = 0;
	[SerializeField]
	int time = 0;
	
	private static string m_path = Application.streamingAssetsPath + "/AnalyticsData";
	
    // Start is called before the first frame update
    void Start()
	{
		Debug.Log("DELETE " + m_path);
		File.Delete(m_path + "/" + SceneManager.GetActiveScene().name + " deaths.txt");
		File.Delete(m_path + "/" + SceneManager.GetActiveScene().name + " gems.txt");
		
		#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
         #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
