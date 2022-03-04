using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.DomainModel;
using Store.Domain.Repositories;

namespace Store.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreRespository _storeRespository;

    public StoreController(IStoreRespository storeRespository)
    {
        _storeRespository = storeRespository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(StoreDomain), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post([FromBody] StoreDomain request)
    {
        var result = await _storeRespository.Post(request);
        return Ok(result);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StoreDomain>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get()
    {
        var result = await _storeRespository.Get();
        return Ok(result);
    }
}