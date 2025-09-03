using UnityEngine;

public class PlayerState : BasePlayerState
{
    private bool _isFirstPlayer;
    private Constants.PlayerType _PlayerType;
    
    public PlayerState(bool isFirstPlayer)
    {
        _isFirstPlayer = isFirstPlayer;
        _PlayerType = _isFirstPlayer ? Constants.PlayerType.PlayerA : Constants.PlayerType.PlayerB;
    }
    
    #region 필수 메서드
    public override void OnEnter(GameLogic gameLogic)
    {
        gameLogic.blockController.OnBlockClickedDelegate = (row, col) =>
        {
            HandleMove(gameLogic, row, col);
        };
    }

    public override void OnExit(GameLogic gameLogic)
    {
        gameLogic.blockController.OnBlockClickedDelegate = null;
    }

    public override void HandleMove(GameLogic gameLogic, int row, int col)
    {
        ProcessMove(gameLogic, _PlayerType, row, col);
    }

    protected override void HandleNextTurn(GameLogic gameLogic)
    {
        if (_isFirstPlayer)
        {
            
        }
        else
        {
            
        }
    }
    #endregion
}
