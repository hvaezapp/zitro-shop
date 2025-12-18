using Microsoft.AspNetCore.Mvc;
using ZitroShop.Api.DTOs.Payment;
using ZitroShop.Modules.PaymentModule.Contracts;
using ZitroShop.Modules.PaymentModule.DTOs;

namespace ZitroShop.Api.Controllers;

[Route("payment")]
public class PaymentController : BaseController
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("start")]
    public async Task<ActionResult<StartPaymentResultDto>> Start([FromBody] StartPaymentRequestDto request, CancellationToken ct)
    {
        var result = await _paymentService.Start(request.UserId, ct);
        return Ok(result);
    }

    [HttpGet("{paymentId}")]
    public async Task<ActionResult<PaymentStatusDto>> Status(long paymentId, CancellationToken ct)
    {
        var result = await _paymentService.GetStatus(paymentId, ct);
        return Ok(result);
    }
}
