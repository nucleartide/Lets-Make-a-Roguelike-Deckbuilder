using UnityEngine;

[CreateAssetMenu]
public class TurnKeeper : ScriptableObject
{
	/// <summary>
    /// Initial turn phase upon start of game.
    /// </summary>
	TurnPhase turnPhase = TurnPhase.PlayerDrawsCards;

	public TurnPhase CurrentTurnPhase
	{
		get { return turnPhase; }
		set { turnPhase = value; }
    }

#if false

[x] Turns
[x] play cards phase
[x] consider turn order, or leave for another GitHub isse - don't need for MVP
[x] opponent performs the same phases
[x] combat phase: play now proceeds into the combat phase

    [ ] PlayerDrawsCards,
    [ ] PlayerPlaysCards,
		[ ] TODO: can end turn by clicking a bell in the center-left of the table
    [ ] PlayerCombatPhase,
		[ ] monsters on the field can now attack the opponent directly (since the opponent can't yet place monsters)
		[ ] attack points will create tokens that accrue on the opponent's side of the scale
    [ ] OpponentDrawsCards,
    [ ] OpponentPlaysCards,
    [ ] OpponentCombatPhase,
    [ ] * Game loop debugging, phases should be visualized through text, perhaps in the horizontal and vertical center of the screen
    [ ] * game loop repetition: turns should be able to loop around. that is, after a turn ends, the next turn begins, up until one of the players wins or loses

#endif
}
