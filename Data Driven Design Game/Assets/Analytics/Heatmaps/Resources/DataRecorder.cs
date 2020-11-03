using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * this Heatmap tool was originally developed by: Garen O'Donnell
 * Date Created: 04/10/2019
 * 
 * Modified by: Hadi Mehrpouya
 * Date modified: 14/10/2020
 * 
 * Modified by: Morgan Skillicorn
 * Date last modified: 18/10/2020
 */

public static class DataRecorder {
	public static string m_path = Application.streamingAssetsPath + "/AnalyticsData";

	public static bool recordDeathPosition2D(Vector2 _pos)
	{
		string filePath = m_path + "/" + SceneManager.GetActiveScene().name + " deaths";

		Debug.Log(filePath + ".txt");

		bool result = false;
		string lineToAdd = _pos.x + "," + _pos.y;
		using (StreamWriter sw = File.AppendText(filePath + ".txt")) //This line will try to open the file and if it doesn't exist, if will make it!
		{
			//Write death position vector to our text file as a new line
			sw.WriteLine(lineToAdd);
			sw.Close();
		}
		////Re-import the file to update the reference in the editor
#if UNITY_EDITOR
		AssetDatabase.ImportAsset(filePath + ".txt");
		TextAsset asset = Resources.Load<TextAsset>(filePath + ".txt");
#endif
		////Print the text from the file
		result = true;//If we get to this part of our code, this means things went ok, so we return true. 
		return result;
	}
	
	public static bool recordGemPosition2D(Vector2 _pos)
	{
		string filePath = m_path + "/" + SceneManager.GetActiveScene().name + " gems";

		Debug.Log(filePath + ".txt");

		bool result = false;
		string lineToAdd = _pos.x + "," + _pos.y;
		using (StreamWriter sw = File.AppendText(filePath + ".txt")) //This line will try to open the file and if it doesn't exist, if will make it!
		{
			//Write death position vector to our text file as a new line
			sw.WriteLine(lineToAdd);
			sw.Close();
		}
		////Re-import the file to update the reference in the editor
#if UNITY_EDITOR
		AssetDatabase.ImportAsset(filePath + ".txt");
		TextAsset asset = Resources.Load<TextAsset>(filePath + ".txt");
#endif
		////Print the text from the file
		result = true;//If we get to this part of our code, this means things went ok, so we return true. 
		return result;
	}
}
