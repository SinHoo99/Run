public class GameManager : Singleton<GameManager>
{

    protected override void Awake()
    {
        // 기존 GameManager가 존재하면 새로 생성된 GameManager 파괴
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        base.Awake(); // 싱글톤 인스턴스 초기화
        DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않도록 설정
    }

    public Player Player;
    public int HighScore { get; private set; }
    public int TotalScore { get; private set; }

    public GameData gameData = new GameData(); // 여전히 GameManager에서 관리
    public SaveManager saveManager; // 인스펙터에서 할당

    private void Start()
    {
        if (saveManager != null)
        {
            gameData = saveManager.LoadGameData();
            HighScore = gameData.highScore;
            TotalScore = gameData.totalScore;
            Player.ApplySprite(gameData.playerSpritePath);
        }
    }
    public void SetPlayer(Player player)
    {
        Player = player;
    }

    private void OnApplicationQuit()
    {
        if (saveManager != null)
        {
            saveManager.SaveGameData(gameData);
        }
    }

    #region 나중에 할 것 점수 관련

    public void UpdateHighScore(int newScore)
    {
        if (newScore > HighScore)
        {
            HighScore = newScore;
            gameData.highScore = HighScore;
            if (saveManager != null)
            {
                saveManager.SaveGameData(gameData);
            }
        }
    }

    public void AddToTotalScore(int scoreToAdd)
    {
        TotalScore += scoreToAdd;
        gameData.totalScore = TotalScore;
        if (saveManager != null)
        {
            saveManager.SaveGameData(gameData);
        }
    }
    #endregion
}
