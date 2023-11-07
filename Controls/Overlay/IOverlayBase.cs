using Microsoft.AspNetCore.Components;

namespace Arkanium.Controls.Overlay;

public interface IOverlayBase : IComponent
{
    public Guid InstanceId { get; }
}
