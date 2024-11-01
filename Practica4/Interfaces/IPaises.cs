namespace Practica4.Interfaces
{
    public interface IPaises
    {
        string ListarPaises();
        string ListarPaisesPorContinente(string continente);
        string ListarPaisesMayorPoblacion(int cantidad);
        string[] ObtenerPrimerNombreApellido(string nombreCompleto);
    }
}

