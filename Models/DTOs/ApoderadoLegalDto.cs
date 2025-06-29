public class ApoderadoLegalDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Cedula { get; set; } = "";
    public bool Idoneidad { get; set; }
    public string Email { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Direccion { get; set; } = "";
    public bool EsFirmaAbogados { get; set; }
    public string FirmaAbogadosNombre { get; set; } = "";
}