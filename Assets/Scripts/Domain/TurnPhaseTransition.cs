public struct TurnPhaseTransition
{
    public TurnPhase CurrentTurnPhase;
    public TurnPhase NextTurnPhase;

    public TurnPhaseTransition(TurnPhase currentTurnPhase, TurnPhase nextTurnPhase)
    {
        CurrentTurnPhase = currentTurnPhase;
        NextTurnPhase = nextTurnPhase;
    }
}
