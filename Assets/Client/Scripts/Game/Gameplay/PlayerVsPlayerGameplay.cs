

public class PlayerVsPlayerGameplay : AGameplay
{

    private const int MOVE_TIME = 10;
    
    public PlayerVsPlayerGameplay(DataManager dataManager):base(dataManager,GameEnum.GameplayType.TwoPlayers)
    {
        _dataManager.InitializeGameData();
    }


    public override void PrepareGameRound()
    {
        base.PrepareGameRound();
        
        FirstPlayer = new Player("Player One", GameEnum.PlayersNumber.PlayerOne);
        SecondPlayer = new Player("Player Two", GameEnum.PlayersNumber.PlayerTwo);

        CallPrepareRoundAction();
        
    }
    

    private void EndRoundTime()
    {
        StopMoveTimer();
        
        if(FirstPlayer.GameItem == GameEnum.GameItem.None) SelectItem(GameEnum.PlayersNumber.PlayerOne);
        if(SecondPlayer.GameItem == GameEnum.GameItem.None) SelectItem(GameEnum.PlayersNumber.PlayerTwo);
    }

    public override void NextRoundStep()
    {
        base.NextRoundStep();
        
        StartMoveTimer(MOVE_TIME, EndRoundTime);
    }

    protected override void EndRoundStep()
    {
        base.EndRoundStep();
        
        StopMoveTimer();
    }

    public override void StartRound()
    {
        base.StartRound();
        
        StartMoveTimer(MOVE_TIME, EndRoundTime);
    }


    public override void EndGame()
    {
        base.EndGame();
        
        StopMoveTimer();
    }
}
