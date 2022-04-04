namespace TicTacToe.Scripts.Components
{
    public struct CellContentComponent
    {
        public CellEnum Content;
    }
    
    public enum CellEnum
    {
        Empty,
        Zero,
        Cross
    }
}