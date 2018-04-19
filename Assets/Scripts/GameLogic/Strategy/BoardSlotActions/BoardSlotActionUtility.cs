namespace Assets.Scripts.GameLogic.Strategy.BoardSlotActions
{
    public class BoardSlotActionUtility : BoardSlotAction
    {
        public override void ExecuteAction()
        {
            // TODO: Implement logic
            // If the utility has no owner and player chooses to buy it, call OnBuyFreeLot
            // If the utility has no owner and player chooses not to buy it, call OnAuction
            // If the utility has owner and player has no funds to pay rent, call OnPlayerBankrupt
            // If the utility has owner and player has funds to pay rent
            //     - Create a debt transaction between the player and the owner
            //     - Execute transaction
            //     - Remove LotCard from bank
            //     - Add LotCard to the player
        }
    }
}
