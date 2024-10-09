using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Organizer.Web.Models
{
    public partial class PlayerPairParameter : GeneratedParameterDto<Organizer.Data.Services.ITournamentService.PlayerPair>
    {
        public PlayerPairParameter() { }

        private Organizer.Data.Services.ITournamentService.OutcomeType? _Outcome;

        public Organizer.Data.Services.ITournamentService.OutcomeType? Outcome
        {
            get => _Outcome;
            set { _Outcome = value; Changed(nameof(Outcome)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Organizer.Data.Services.ITournamentService.PlayerPair entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Outcome))) entity.Outcome = Outcome;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Organizer.Data.Services.ITournamentService.PlayerPair MapToNew(IMappingContext context)
        {
            var entity = new Organizer.Data.Services.ITournamentService.PlayerPair();
            MapTo(entity, context);
            return entity;
        }
    }

    public partial class PlayerPairResponse : GeneratedResponseDto<Organizer.Data.Services.ITournamentService.PlayerPair>
    {
        public PlayerPairResponse() { }

        public Organizer.Data.Services.ITournamentService.OutcomeType? Outcome { get; set; }
        public Organizer.Web.Models.PlayerResponse Black { get; set; }
        public Organizer.Web.Models.PlayerResponse White { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Organizer.Data.Services.ITournamentService.PlayerPair obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.Outcome = obj.Outcome;
            if (tree == null || tree[nameof(this.Black)] != null)
                this.Black = obj.Black.MapToDto<Organizer.Data.Models.Player, PlayerResponse>(context, tree?[nameof(this.Black)]);

            if (tree == null || tree[nameof(this.White)] != null)
                this.White = obj.White.MapToDto<Organizer.Data.Models.Player, PlayerResponse>(context, tree?[nameof(this.White)]);

        }
    }
}
