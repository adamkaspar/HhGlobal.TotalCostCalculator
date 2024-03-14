using System.Net;

namespace HhGlobal.TotalCostCalculator.API.Dto;

public class ExceptionDto
{
    public Guid CorrelationId{ get; set; }

    public HttpStatusCode StatusCode{ get; set; }

    public string Message{ get; set; }
}
