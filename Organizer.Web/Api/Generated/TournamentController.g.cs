
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
    [Route("api/Tournament")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class TournamentController
        : BaseApiController<Organizer.Data.Models.Tournament, TournamentParameter, TournamentResponse, Organizer.Data.AppDbContext>
    {
        public TournamentController(CrudContext<Organizer.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Organizer.Data.Models.Tournament>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<TournamentResponse>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<Organizer.Data.Models.Tournament> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<TournamentResponse>> List(
            ListParameters parameters,
            IDataSource<Organizer.Data.Models.Tournament> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Organizer.Data.Models.Tournament> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<TournamentResponse>> Save(
            [FromForm] TournamentParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Organizer.Data.Models.Tournament> dataSource,
            IBehaviors<Organizer.Data.Models.Tournament> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<TournamentResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Organizer.Data.Models.Tournament> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<TournamentResponse>> Delete(
            string id,
            IBehaviors<Organizer.Data.Models.Tournament> behaviors,
            IDataSource<Organizer.Data.Models.Tournament> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
