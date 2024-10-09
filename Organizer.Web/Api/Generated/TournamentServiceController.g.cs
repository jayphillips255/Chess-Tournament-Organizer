
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organizer.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Organizer.Web.Api
{
    [Route("api/TournamentService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class TournamentServiceController : Controller
    {
        protected ClassViewModel GeneratedForClassViewModel { get; }
        protected Organizer.Data.Services.ITournamentService Service { get; }
        protected CrudContext Context { get; }

        public TournamentServiceController(CrudContext context, Organizer.Data.Services.ITournamentService service)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Organizer.Data.Services.ITournamentService>();
            Service = service;
            Context = context;
        }

        /// <summary>
        /// Method: GetPlayerPairs
        /// </summary>
        [HttpPost("GetPlayerPairs")]
        [Authorize]
        public virtual ItemResult<PlayerPairResponse[]> GetPlayerPairs(
            [FromForm(Name = "thisTournamentId")] string thisTournamentId)
        {
            var _params = new
            {
                thisTournamentId = thisTournamentId
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("GetPlayerPairs"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return new ItemResult<PlayerPairResponse[]>(_validationResult);
            }

            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(Context);
            var _methodResult = Service.GetPlayerPairs(
                _params.thisTournamentId
            );
            var _result = new ItemResult<PlayerPairResponse[]>();
            _result.Object = _methodResult?.ToList().Select(o => Mapper.MapToDto<Organizer.Data.Services.ITournamentService.PlayerPair, PlayerPairResponse>(o, _mappingContext, includeTree)).ToArray();
            return _result;
        }

        /// <summary>
        /// Method: UpdatePlayers
        /// </summary>
        [HttpPost("UpdatePlayers")]
        [Authorize]
        public virtual ItemResult UpdatePlayers(
            [FromForm(Name = "games")] GameParameter[] games,
            [FromForm(Name = "tournamentId")] string tournamentId)
        {
            var _params = new
            {
                games = !Request.Form.HasAnyValue(nameof(games)) ? null : games.ToList(),
                tournamentId = tournamentId
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("UpdatePlayers"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return _validationResult;
            }

            var _mappingContext = new MappingContext(Context);
            Service.UpdatePlayers(
                _params.games?.Select(_m => _m.MapToNew(_mappingContext)).ToArray(),
                _params.tournamentId
            );
            var _result = new ItemResult();
            return _result;
        }
    }
}
