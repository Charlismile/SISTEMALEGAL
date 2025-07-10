namespace SISTEMALEGAL.DTOs;

public class RegistroAsociacionDTO
{
    public string NombreAsociacion { get; set; }
    public int Folio { get; set; }
    public string Actividad { get; set; }

    public RepresentanteLegalDTO Representante { get; set; }
    public ApoderadoLegalDTO Apoderado { get; set; }
}