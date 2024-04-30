using Content.Client.Weapons.Ranged.Systems;
using Content.Shared.Weapons.Ranged.Systems;

namespace Content.Client.Weapons.Ranged;

/// <summary>
/// Visualizer for gun mag presence; can change states based on ammo count or toggle visibility entirely.
/// </summary>
[RegisterComponent, Access(typeof(GunSystem))]
public sealed partial class BatteryGunFireModeVisuals : byte
{
    [Dependency] private readonly MagazineVisualsComponent _magazineVisualsComponent = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<BatteryWeaponFireModesSystem, FireModeSetEvent>(OnFireModeSet);
    }

    public void OnFireModeSet(ref FireModeSetEvent ev)
    {
        _magazineVisualsComponent.MagState = ev.ModeMagSprite;
    }
}