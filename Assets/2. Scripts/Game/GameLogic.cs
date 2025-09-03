using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameLogic : MonoBehaviour
{
    public BlockController blockController;

    private Constants.PlayerType[,] _board;

    public BasePlayerState firstPlayerState;
    public BasePlayerState secondPlayerState;

    public enum GameResult { None, Win, Lose, Draw }
    
    public BasePlayerState _currentPlayerState;
    
    public GameLogic(BlockController blockController, Constants.GameType gameType)
    {
        this.blockController = blockController;

        _board = new Constants.PlayerType[Constants.BlockColumnCount, Constants.BlockColumnCount];

        switch (gameType)
        {
            case Constants.GameType.SinglePlay:
                break;
            case Constants.GameType.DualPlay:
                firstPlayerState = new PlayerState(true);
                secondPlayerState = new PlayerState(false);
                SetState(firstPlayerState);
                break;
            case Constants.GameType.MutiPlay:
                break;
            }
    }

    public void SetState(BasePlayerState state)
    {
        _currentPlayerState?.OnExit(this);
        _currentPlayerState = state;
        _currentPlayerState?.OnEnter(this);
    }

    public bool SetNewBoardValue(Constants.PlayerType playerType, int row, int col)
    {
        if (_board[row, col] != Constants.PlayerType.None) return false;

        if (playerType == Constants.PlayerType.PlayerA)
        {
            _board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.O, row, col);
            return true;
        }
        else if(playerType == Constants.PlayerType.PlayerB)
        {
            _board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.X, row, col);
            return true;
        }

        return false;
    }

    public void EndGame(GameResult gameResult)
    {
        SetState(null);
        firstPlayerState = null;
        secondPlayerState = null;
    }

    public GameResult CheckGameResult()
    {
        if (CheckGameWin(Constants.PlayerType.PlayerA, _board))
            return GameResult.Win;
        
        if(CheckGameWin(Constants.PlayerType.PlayerB, _board))
            return GameResult.Lose;
        
        if(CheckGameDraw(_board))
            return GameResult.Draw;

        return GameResult.None;
    }

    public bool CheckGameDraw(Constants.PlayerType[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == Constants.PlayerType.None) return false;
            }
        }

        return true;
    }

    private bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] == playerType &&
                board[row, 1] == playerType &&
                board[row, 2] == playerType)
            {
                return true;
            }
        }

        for (var col = 0; col < board.GetLength(1); col++)
        {
            if (board[col, 0] == playerType &&
                board[col, 1] == playerType &&
                board[col, 2] == playerType)
            {
                return true;
            }
        }
        
        if (board[0, 0] == playerType &&
            board[1, 1] == playerType &&
            board[2, 2] == playerType)
        {
            return true;
        }
        
        if (board[0, 2] == playerType &&
            board[1, 1] == playerType &&
            board[2, 0] == playerType)
        {
            return true;
        }

        return false;
    }
}
