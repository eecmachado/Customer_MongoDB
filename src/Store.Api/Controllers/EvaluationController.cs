using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.DomainModel;
using Store.Domain.Repositories;

namespace Store.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EvaluationController : ControllerBase
{
    private readonly IEvaluationRespository _evaluationRespository;

    public EvaluationController(IEvaluationRespository evaluationRespository)
    {
        _evaluationRespository = evaluationRespository;
    }

    [HttpPatch("{storeId}/Evaluate")]
    [ProducesResponseType(typeof(EvaluationDomain), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Patch(string storeId, [FromBody] EvaluationDomain request)
    {
        var result = await _evaluationRespository.Evaluate(storeId, request);
        return Ok(result);
    }
}