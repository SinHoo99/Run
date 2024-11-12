using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/gameData.json";
    }

    public void SaveGameData(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("게임 데이터가 저장되었습니다: " + filePath);
    }

    public GameData LoadGameData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("게임 데이터가 로드되었습니다.");
            return gameData;
        }
        else
        {
            Debug.LogWarning("저장된 게임 데이터를 찾을 수 없습니다: " + filePath);
            return new GameData(); // 기본값 반환
        }
    }
}
