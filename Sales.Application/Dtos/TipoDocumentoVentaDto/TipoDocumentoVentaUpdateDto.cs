namespace Sales.Application.Dtos.TipoDocumentoVentaDto;

public class TipoDocumentoVentaUpdateDto
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
}