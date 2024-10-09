using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Organizer.Web.Models
{
    public partial class TournamentParameter : GeneratedParameterDto<Organizer.Data.Models.Tournament>
    {
        public TournamentParameter() { }

        private string _TournamentId;
        private string _Name;
        private Organizer.Data.Models.Type? _Type;
        private System.DateTime? _DateTime;
        private int? _CurrentRound;

        public string TournamentId
        {
            get => _TournamentId;
            set { _TournamentId = value; Changed(nameof(TournamentId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public Organizer.Data.Models.Type? Type
        {
            get => _Type;
            set { _Type = value; Changed(nameof(Type)); }
        }
        public System.DateTime? DateTime
        {
            get => _DateTime;
            set { _DateTime = value; Changed(nameof(DateTime)); }
        }
        public int? CurrentRound
        {
            get => _CurrentRound;
            set { _CurrentRound = value; Changed(nameof(CurrentRound)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Organizer.Data.Models.Tournament entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Type))) entity.Type = (Type ?? entity.Type);
            if (ShouldMapTo(nameof(DateTime))) entity.DateTime = (DateTime ?? entity.DateTime);
            if (ShouldMapTo(nameof(CurrentRound))) entity.CurrentRound = (CurrentRound ?? entity.CurrentRound);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Organizer.Data.Models.Tournament MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Organizer.Data.Models.Tournament()
            {
                TournamentId = TournamentId,
                Name = Name,
                Type = (Type ?? default),
                DateTime = (DateTime ?? default),
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(CurrentRound))) entity.CurrentRound = (CurrentRound ?? entity.CurrentRound);

            return entity;
        }
    }

    public partial class TournamentResponse : GeneratedResponseDto<Organizer.Data.Models.Tournament>
    {
        public TournamentResponse() { }

        public string TournamentId { get; set; }
        public string Name { get; set; }
        public Organizer.Data.Models.Type? Type { get; set; }
        public System.DateTime? DateTime { get; set; }
        public int? CurrentRound { get; set; }
        public System.Collections.Generic.ICollection<Organizer.Web.Models.PlayerResponse> Players { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Organizer.Data.Models.Tournament obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.TournamentId = obj.TournamentId;
            this.Name = obj.Name;
            this.Type = obj.Type;
            this.DateTime = obj.DateTime;
            this.CurrentRound = obj.CurrentRound;
            var propValPlayers = obj.Players;
            if (propValPlayers != null && (tree == null || tree[nameof(this.Players)] != null))
            {
                this.Players = propValPlayers
                    .OrderBy(f => f.PlayerId)
                    .Select(f => f.MapToDto<Organizer.Data.Models.Player, PlayerResponse>(context, tree?[nameof(this.Players)])).ToList();
            }
            else if (propValPlayers == null && tree?[nameof(this.Players)] != null)
            {
                this.Players = new PlayerResponse[0];
            }

        }
    }
}
