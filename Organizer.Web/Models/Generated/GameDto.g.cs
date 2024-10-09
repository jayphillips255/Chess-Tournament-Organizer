using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Organizer.Web.Models
{
    public partial class GameParameter : GeneratedParameterDto<Organizer.Data.Services.ITournamentService.Game>
    {
        public GameParameter() { }

        private string _BlackId;
        private string _WhiteId;
        private Organizer.Data.Services.ITournamentService.OutcomeType? _Outcome;

        public string BlackId
        {
            get => _BlackId;
            set { _BlackId = value; Changed(nameof(BlackId)); }
        }
        public string WhiteId
        {
            get => _WhiteId;
            set { _WhiteId = value; Changed(nameof(WhiteId)); }
        }
        public Organizer.Data.Services.ITournamentService.OutcomeType? Outcome
        {
            get => _Outcome;
            set { _Outcome = value; Changed(nameof(Outcome)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Organizer.Data.Services.ITournamentService.Game entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(BlackId))) entity.BlackId = BlackId;
            if (ShouldMapTo(nameof(WhiteId))) entity.WhiteId = WhiteId;
            if (ShouldMapTo(nameof(Outcome))) entity.Outcome = (Outcome ?? entity.Outcome);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Organizer.Data.Services.ITournamentService.Game MapToNew(IMappingContext context)
        {
            var entity = new Organizer.Data.Services.ITournamentService.Game();
            MapTo(entity, context);
            return entity;
        }
    }

    public partial class GameResponse : GeneratedResponseDto<Organizer.Data.Services.ITournamentService.Game>
    {
        public GameResponse() { }

        public string BlackId { get; set; }
        public string WhiteId { get; set; }
        public Organizer.Data.Services.ITournamentService.OutcomeType? Outcome { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Organizer.Data.Services.ITournamentService.Game obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.BlackId = obj.BlackId;
            this.WhiteId = obj.WhiteId;
            this.Outcome = obj.Outcome;
        }
    }
}
