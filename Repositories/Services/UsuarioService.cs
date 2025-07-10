using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using SISTEMALEGAL.Repositories.Interfaces;

public class UsuarioService : IUsuarioService
{
    private readonly AuthenticationStateProvider _authProvider;

    public UsuarioService(AuthenticationStateProvider authProvider) => _authProvider = authProvider;

    public async Task<string> ObtenerUsuarioActualId()
    {
        var authState = await _authProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public async Task<bool> TienePermiso(string usuarioId, string permiso)
    {
        // Aquí puedes verificar roles o claims del usuario
        return true; // Ejemplo básico
    }
}