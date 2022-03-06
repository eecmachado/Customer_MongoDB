using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.DomainModel;
using Store.Domain.Repositories;

namespace Store.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreEvaluationController : ControllerBase
{
    private readonly IStoreEvaluationRepository _storeEvaluationRepository;

    public StoreEvaluationController(IStoreEvaluationRepository storeEvaluationRepository)
    {
        _storeEvaluationRepository = storeEvaluationRepository;
    }
    
    [HttpGet("{storeId}")]
    [ProducesResponseType(typeof(StoreEvaluationDomain), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get(string storeId)
    {
        var result = await _storeEvaluationRepository.GetStoreEvaluation(storeId);
        return Ok(result);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StoreEvaluationDomain>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get()
    {
        var result = await _storeEvaluationRepository.GetStoresEvaluation();
        return Ok(result);
    }
    
    [HttpGet("GetBestPlaces/{quantity}")]
    [ProducesResponseType(typeof(IEnumerable<StoreEvaluationDomain>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetBestPlaces(int quantity)
    {
        var result = await _storeEvaluationRepository.GetBestEvaluatedPlace(quantity);
        return Ok(result);
    }
}