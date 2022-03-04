using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.DomainModel;
using Store.Domain.Enumerators;
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

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(StoreDomain), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Put(string id, [FromBody] StoreDomain request)
    {
        var result = await _storeRespository.Update(id, request);
        return Ok(result);
    }
    
    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(StoreDomain), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Patch(string id,[FromBody] StoreType type)
    {
        var result = await _storeRespository.UpdateType(id, type);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(string id)
    {
        var result = await _storeRespository.Delete(id);
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

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(StoreDomain), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get(string id)
    {
        var result = await _storeRespository.Get(id);
        return Ok(result);
    }

    [HttpGet("GetByType/{type}")]
    [ProducesResponseType(typeof(IEnumerable<StoreDomain>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get(StoreType type)
    {
        var result = await _storeRespository.Get(type);
        return Ok(result);
    }
}