using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Heatmap_BombDrop : MonoBehaviour
{
    private static List<Vector2> m_deathPositions = new List<Vector2>();
    private static GameObject heatmapPrefab;
    private static string m_path = Application.streamingAssetsPath + "/AnalyticsData";

#if UNITY_EDITOR
	[MenuItem("Tools/Heatmap/Generate Death Heatmap")]
	static void ReadDeathData()
	{
		m_deathPositions.Clear();

		string filePath = m_path + "/" + SceneManager.GetActiveScene().name + " deaths";
		heatmapPrefab = (GameObject)Resources.Load("prefabs/heatmapMarkerPrefab", typeof(GameObject));//Prefab to use to render death positions.

		//Read the text from directly from the txt file
		string fullPath = filePath + ".txt";
		StreamReader reader = new StreamReader(fullPath);

		reader = new StreamReader(fullPath);

		string deathCoords = "";
		while ((deathCoords = reader.ReadLine()) != null) {//going through the text file line by line and adding it to a list of vectors.
			m_deathPositions.Add(stringToVec(deathCoords));
			deathCoords = "";
		}
		reader.Close();
		renderDeathData();
	}
	
	[MenuItem("Tools/Heatmap/Generate Gem Heatmap")]
	static void ReadGemData()
	{
		m_deathPositions.Clear();

		string filePath = m_path + "/" + SceneManager.GetActiveScene().name + " gems";
		heatmapPrefab = (GameObject)Resources.Load("prefabs/heatmapMarkerPrefab", typeof(GameObject));//Prefab to use to render death positions.

		//Read the text from directly from the txt file
		string fullPath = filePath + ".txt";
		StreamReader reader = new StreamReader(fullPath);

		reader = new StreamReader(fullPath);

		string deathCoords = "";
		while ((deathCoords = reader.ReadLine()) != null) {//going through the text file line by line and adding it to a list of vectors.
			m_deathPositions.Add(stringToVec(deathCoords));
			deathCoords = "";
		}
		reader.Close();
		renderDeathData();
	}
#endif


    public static Vector2 stringToVec(string _st)
    {
        Vector2 result = new Vector2();
        string[] vals = _st.Split(',');
        if (vals.Length == 2)
        {
            result.Set(float.Parse(vals[0]), float.Parse(vals[1]));
        }
        return result;
    }

    public static void renderDeathData()
    {
        foreach (Vector2 deathPos in m_deathPositions) {

            Instantiate(heatmapPrefab, deathPos, Quaternion.identity);
        }
    }

#if UNITY_EDITOR
    [MenuItem("Tools/Heatmap/Clear")]
    public static void destroyHeatmapObjects()
    {
            GameObject[] hMap_Spheres = GameObject.FindGameObjectsWithTag("heatmap");
            for (int i = 0; i < hMap_Spheres.Length; i++)
            {
                GameObject.DestroyImmediate(hMap_Spheres[i]);
            }
    }
#endif
}
