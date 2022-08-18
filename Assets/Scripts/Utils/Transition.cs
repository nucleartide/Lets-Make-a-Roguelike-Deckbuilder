public static class Transition
{
    public static TurnPhaseTransition EndPlayCards =
        new TurnPhaseTransition(TurnPhase.PlayerPlaysCards, TurnPhase.PlayerCombatPhase);
}
