namespace Entities.FogOfWar
{
    public interface IFOWShowable
    {
        public void TryAddFOWViewable(IFOWViewable FOWWhichSee);

        public void TryRemoveFOWViewable(IFOWViewable FOWWhichSee);

        public void ShowElementsRPC();

        public void HideElementsRPC();
    }
}