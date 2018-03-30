using System;

public class StateOnAuction : State
{
	public StateOnAuction(GameStateMachine gameStateMachine) : base(gameStateMachine)
    {
	}

    public override void ExecuteGameLogic()
    {
        // TODO: Implement logic
        // Create an instance of Auction
        // Put every player inside it
        // In a loop receive bids and quits
        //     - The bidders must be diffent from the current highest bid bidder
        // When only one player left in the Auction with the highest bid, finishes it
        // Create a Transaction between the buyer and the seller
        // Execute the Transaction
        // Transfer ownership
    }
}
