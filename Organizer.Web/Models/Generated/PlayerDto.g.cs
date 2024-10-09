using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Organizer.Web.Models
{
    public partial class PlayerParameter : GeneratedParameterDto<Organizer.Data.Models.Player>
    {
        public PlayerParameter() { }

        private string _PlayerId;
        private string _FirstName;
        private string _LastName;
        private string _Rating;
        private double? _Score;
        private int? _NumGamesAsBlack;
        private int? _NumGamesAsWhite;
        private bool? _ReceivedFullPointBye;
        private bool? _HasHalfPointBye;
        private string _TournamentId;

        public string PlayerId
        {
            get => _PlayerId;
            set { _PlayerId = value; Changed(nameof(PlayerId)); }
        }
        public string FirstName
        {
            get => _FirstName;
            set { _FirstName = value; Changed(nameof(FirstName)); }
        }
        public string LastName
        {
            get => _LastName;
            set { _LastName = value; Changed(nameof(LastName)); }
        }
        public string Rating
        {
            get => _Rating;
            set { _Rating = value; Changed(nameof(Rating)); }
        }
        public double? Score
        {
            get => _Score;
            set { _Score = value; Changed(nameof(Score)); }
        }
        public int? NumGamesAsBlack
        {
            get => _NumGamesAsBlack;
            set { _NumGamesAsBlack = value; Changed(nameof(NumGamesAsBlack)); }
        }
        public int? NumGamesAsWhite
        {
            get => _NumGamesAsWhite;
            set { _NumGamesAsWhite = value; Changed(nameof(NumGamesAsWhite)); }
        }
        public bool? ReceivedFullPointBye
        {
            get => _ReceivedFullPointBye;
            set { _ReceivedFullPointBye = value; Changed(nameof(ReceivedFullPointBye)); }
        }
        public bool? HasHalfPointBye
        {
            get => _HasHalfPointBye;
            set { _HasHalfPointBye = value; Changed(nameof(HasHalfPointBye)); }
        }
        public string TournamentId
        {
            get => _TournamentId;
            set { _TournamentId = value; Changed(nameof(TournamentId)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Organizer.Data.Models.Player entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(FirstName))) entity.FirstName = FirstName;
            if (ShouldMapTo(nameof(LastName))) entity.LastName = LastName;
            if (ShouldMapTo(nameof(Rating))) entity.Rating = Rating;
            if (ShouldMapTo(nameof(Score))) entity.Score = (Score ?? entity.Score);
            if (ShouldMapTo(nameof(NumGamesAsBlack))) entity.NumGamesAsBlack = (NumGamesAsBlack ?? entity.NumGamesAsBlack);
            if (ShouldMapTo(nameof(NumGamesAsWhite))) entity.NumGamesAsWhite = (NumGamesAsWhite ?? entity.NumGamesAsWhite);
            if (ShouldMapTo(nameof(ReceivedFullPointBye))) entity.ReceivedFullPointBye = (ReceivedFullPointBye ?? entity.ReceivedFullPointBye);
            if (ShouldMapTo(nameof(HasHalfPointBye))) entity.HasHalfPointBye = (HasHalfPointBye ?? entity.HasHalfPointBye);
            if (ShouldMapTo(nameof(TournamentId))) entity.TournamentId = TournamentId;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Organizer.Data.Models.Player MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Organizer.Data.Models.Player()
            {
                PlayerId = PlayerId,
                FirstName = FirstName,
                LastName = LastName,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(Rating))) entity.Rating = Rating;
            if (ShouldMapTo(nameof(Score))) entity.Score = (Score ?? entity.Score);
            if (ShouldMapTo(nameof(NumGamesAsBlack))) entity.NumGamesAsBlack = (NumGamesAsBlack ?? entity.NumGamesAsBlack);
            if (ShouldMapTo(nameof(NumGamesAsWhite))) entity.NumGamesAsWhite = (NumGamesAsWhite ?? entity.NumGamesAsWhite);
            if (ShouldMapTo(nameof(ReceivedFullPointBye))) entity.ReceivedFullPointBye = (ReceivedFullPointBye ?? entity.ReceivedFullPointBye);
            if (ShouldMapTo(nameof(HasHalfPointBye))) entity.HasHalfPointBye = (HasHalfPointBye ?? entity.HasHalfPointBye);
            if (ShouldMapTo(nameof(TournamentId))) entity.TournamentId = TournamentId;

            return entity;
        }
    }

    public partial class PlayerResponse : GeneratedResponseDto<Organizer.Data.Models.Player>
    {
        public PlayerResponse() { }

        public string PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rating { get; set; }
        public double? Score { get; set; }
        public int? NumGamesAsBlack { get; set; }
        public int? NumGamesAsWhite { get; set; }
        public bool? ReceivedFullPointBye { get; set; }
        public bool? HasHalfPointBye { get; set; }
        public string TournamentId { get; set; }
        public System.Collections.Generic.ICollection<Organizer.Web.Models.PlayerResponse> PastOpponents { get; set; }
        public Organizer.Web.Models.TournamentResponse Tournament { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Organizer.Data.Models.Player obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.PlayerId = obj.PlayerId;
            this.FirstName = obj.FirstName;
            this.LastName = obj.LastName;
            this.Rating = obj.Rating;
            this.Score = obj.Score;
            this.NumGamesAsBlack = obj.NumGamesAsBlack;
            this.NumGamesAsWhite = obj.NumGamesAsWhite;
            this.ReceivedFullPointBye = obj.ReceivedFullPointBye;
            this.HasHalfPointBye = obj.HasHalfPointBye;
            this.TournamentId = obj.TournamentId;
            var propValPastOpponents = obj.PastOpponents;
            if (propValPastOpponents != null && (tree == null || tree[nameof(this.PastOpponents)] != null))
            {
                this.PastOpponents = propValPastOpponents
                    .OrderBy(f => f.PlayerId)
                    .Select(f => f.MapToDto<Organizer.Data.Models.Player, PlayerResponse>(context, tree?[nameof(this.PastOpponents)])).ToList();
            }
            else if (propValPastOpponents == null && tree?[nameof(this.PastOpponents)] != null)
            {
                this.PastOpponents = new PlayerResponse[0];
            }

            if (tree == null || tree[nameof(this.Tournament)] != null)
                this.Tournament = obj.Tournament.MapToDto<Organizer.Data.Models.Tournament, TournamentResponse>(context, tree?[nameof(this.Tournament)]);

        }
    }
}
