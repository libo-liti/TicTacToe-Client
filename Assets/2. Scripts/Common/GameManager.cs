using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject confirmPanel;
    
    private Constants.GameType _gameType;

    private Canvas _canvas;

    private GameLogic _gameLogic;
    public void ChangeToGameScene(Constants.GameType gameType)
    {
        _gameType = gameType;
        SceneManager.LoadScene("Game");
    }
    
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void OpenConfirmPanel(string message, ConfirmPanelController.OnConfirmButtonClicked onConfirmButtonClicked)
    {
        if (_canvas != null)
        {
            var confirmPanelObject = Instantiate(confirmPanel, _canvas.transform);
            confirmPanelObject.GetComponent<ConfirmPanelController>().Show(message, onConfirmButtonClicked);
        }
    }
    
    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        _canvas = FindFirstObjectByType<Canvas>();
        if (scene.name == "Game")
        {
            var blockController = FindFirstObjectByType<BlockController>();
            blockController.InitBlocks();
            
            if (_gameLogic != null)
            {
            
            }

            _gameLogic = new GameLogic(blockController, _gameType);
        }
    }
}
