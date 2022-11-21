using Photon.Pun;

public interface IFogOfWarViewable
{
    /// <summary>
    /// Get the render range of the Entity
    /// </summary>
    /// <returns></returns>
    float GetViewRange();

    void RequestSetViewRange(float value);

    [PunRPC]void SetViewRangeRPC(float value);
    [PunRPC]void SyncSetViewRangeRPC(float value);
}
