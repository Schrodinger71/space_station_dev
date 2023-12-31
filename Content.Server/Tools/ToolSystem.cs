using Content.Server.Atmos.EntitySystems;
using Content.Server.Popups;
using Content.Server.Tools.Components;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.Maps;
using Content.Shared.Tools;
using Robust.Server.GameObjects;
using Robust.Shared.Audio;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Map;
using SharedToolSystem = Content.Shared.Tools.Systems.SharedToolSystem;

namespace Content.Server.Tools
{
    // TODO move tool system to shared, and make it a friend of Tool Component.
    public sealed partial class ToolSystem : SharedToolSystem
    {
        [Dependency] private readonly IMapManager _mapManager = default!;
        [Dependency] private readonly ITileDefinitionManager _tileDefinitionManager = default!;
        [Dependency] private readonly AppearanceSystem _appearanceSystem = default!;
        [Dependency] private readonly AtmosphereSystem _atmosphereSystem = default!;
        [Dependency] private readonly PopupSystem _popup = default!;
        [Dependency] private readonly SharedAudioSystem _audio = default!;
        [Dependency] private readonly SharedPointLightSystem _light = default!;
        [Dependency] private readonly SolutionContainerSystem _solutionContainer = default!;
        [Dependency] private readonly TransformSystem _transformSystem = default!;

        public override void Initialize()
        {
            base.Initialize();

            InitializeLatticeCutting();
            InitializeWelders();
        }

        public override void Update(float frameTime)
        {
            base.Update(frameTime);

            UpdateWelders(frameTime);
        }

        protected override bool IsWelder(EntityUid uid)
        {
            return HasComp<WelderComponent>(uid);
        }
    }
}
