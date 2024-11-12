using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;

    public void GoStoreScene()
    {
        ChangeScene("StoreScene");
    }

    public void GoMainScene()
    {
        ChangeScene("MainScene");
    }

    private void ChangeScene(string sceneName)
    {
        // 데이터 저장
        GM.saveManager.SaveGameData(GM.gameData);

        // 씬 로드 및 로드 후 스프라이트 적용 이벤트 구독
        SceneManager.LoadScene(sceneName);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드된 후 Player의 스프라이트를 설정
        if (GM.Player != null)
        {
            GM.Player.ApplySprite(GM.gameData.playerSpritePath);
        }

        // 이벤트 구독 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
