
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
    [Route("api/Player")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class PlayerController
        : BaseApiController<Organizer.Data.Models.Player, PlayerParameter, PlayerResponse, Organizer.Data.AppDbContext>
    {
        public PlayerController(CrudContext<Organizer.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Organizer.Data.Models.Player>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PlayerResponse>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<Organizer.Data.Models.Player> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<PlayerResponse>> List(
            ListParameters parameters,
            IDataSource<Organizer.Data.Models.Player> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Organizer.Data.Models.Player> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<PlayerResponse>> Save(
            [FromForm] PlayerParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Organizer.Data.Models.Player> dataSource,
            IBehaviors<Organizer.Data.Models.Player> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<PlayerResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Organizer.Data.Models.Player> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PlayerResponse>> Delete(
            string id,
            IBehaviors<Organizer.Data.Models.Player> behaviors,
            IDataSource<Organizer.Data.Models.Player> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
