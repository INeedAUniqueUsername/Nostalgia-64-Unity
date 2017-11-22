public interface IUsable {
    void Activate();
}
public interface IDevice : IUsable {
    float GetPowerUse();
    void SetActive(bool active);
    bool GetActive();
}