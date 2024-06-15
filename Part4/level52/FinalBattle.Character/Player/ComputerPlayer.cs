namespace FinalBattle.Character.Player
{
    /// <summary>
    ///     A computer/AI player. All decisions are made by the computer.
    /// </summary>
    /// <seealso cref="IPlayer" />
    public class ComputerPlayer : Player
    {
        #region Fields
        private readonly Random _random = new Random();
        #endregion

        #region Constructors
        /// <inheritdoc />
        public ComputerPlayer() {}
        #endregion

        /// <inheritdoc />
        public override Action SelectAction()
        {
            var currentCharacter = CurrentParty.Characters.First(x => x.IsActive);
            Thread.Sleep(500); // simulate decision
            var availableActions = Enum.GetNames(typeof(Action)).ToList();
            if (CurrentParty.PartyInventory.ContainsHealthPotion && currentCharacter.IsWounded && _random.Next(1, 101) <= 25)
            {
                return Action.UseItem;
            }

            // If the character has no gear equipped, and gear is available, always equip it (if the character didn't use a health potion).
            if (currentCharacter.EquippedGear == null && CurrentParty.IsEquippableGearAvailable)
            {
                return Action.Equip;
            }

            availableActions.Remove(Action.UseItem.ToString());
            availableActions.Remove(Action.Equip.ToString());
            var selectedAction = _random.Next(availableActions.Count) + 1;
            return (Action) selectedAction;
        }

        /// <inheritdoc />
        public override int SelectTarget(List<Character> characters) => _random.Next(characters.Count);

        /// <inheritdoc />
        public override void UseItem(int index)
        {
            // Only Health potions at this stage.
            index = 0;
            CurrentParty.PartyInventory.UseItem(CurrentCharacter, index);
        }
    }
}