public interface IMonopolyCore
{

    #region Machine commands

    void ChangeState(State state);
    void ThrowDice(int playerId);
    void ThrowDice(int playerId, int die1, int die2);

    #endregion

    #region Database methods

    void AddBoardSlot(BoardSlot boardSlot);
    void AddChanceCard(ChanceCard chanceCard);
    void AddCommunityChestCard(CommunityChestCard communityChestCard);
    void AddTitleDeedCard(TitleDeedCard titleDeedCard);
    void AddLot(Lot lot);
    void AddRailroadCard(RailroadCard railroadCard);
    void AddUtilityCard(UtilityCard utilityCard);
    void AddPlayer(int id, string name, string playerColor);

    #endregion

    #region Check methods

    bool CheckInState(string stateName);
    bool CheckCanThrowDice(int playerId);
    int GetNumberOfPlayers();
    int GetNumberOfBoardSlots();
    int GetNumberOfChanceCards();
    int GetNumberOfCommunityChestCards();
    int GetNumberOfTitleDeedCards();
    int GetNumberOfRailroadCards();
    int GetNumberOfUtilityCards();
    int GetNumberOfLots();
    int GetNumberOfEnqueuedChanceCards();
    int GetNumberOfEnqueuedCommunityChestCards();
    int GetNumberOfPlayersInGame();
    int GetNumberOfBoardSlotsInBoard();
    int GetNumberOfPlayersInBoardSlot(int index);
    int GetPlayerPositionOnBoard(int playerId);

    #endregion

}
