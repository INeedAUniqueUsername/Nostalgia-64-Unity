using UnityEngine;

interface IWeapon : IDevice {
    int GetCooldown();
    int GetCooldownLeft();
    bool IsReady();
    Transform GetProjectile();
}