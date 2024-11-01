using Practica4.Interfaces;
using Newtonsoft.Json;
using Practica4.Modelos;

namespace Practica4.Servicios
{
    public class PaisesServicio : IPaises
    {
        private readonly List<Paises> _paises;

        public PaisesServicio(IWebHostEnvironment env) 
        {
            string jsonData = File.ReadAllText(Path.Combine(env.ContentRootPath, "Data/Practica4.json"));
            _paises = JsonConvert.DeserializeObject<List<Paises>>(jsonData) ?? new List<Paises>();
        }



        public string ListarPaises()
        {
            return JsonConvert.SerializeObject(_paises, Formatting.Indented);
        }

        public string ListarPaisesPorContinente(string continente)
        {
            var paisesContinente = _paises.Where(p => p.Continente.Equals(continente, StringComparison.OrdinalIgnoreCase));
            return JsonConvert.SerializeObject(paisesContinente, Formatting.Indented);
        }

        public string ListarPaisesMayorPoblacion(int cantidad)
        {
           
            for (int i = 0; i < _paises.Count - 1; i++)
            {
                for (int j = 0; j < _paises.Count - 1 - i; j++)
                {
                    if (_paises[j].Poblacion < _paises[j + 1].Poblacion)
                    {
                        var temp = _paises[j];
                        _paises[j] = _paises[j + 1];
                        _paises[j + 1] = temp;
                    }
                }
            }

            var paisesConMayorPoblacion = _paises.Take(cantidad).ToList();

            return JsonConvert.SerializeObject(paisesConMayorPoblacion, Formatting.Indented);
        }



        public string[] ObtenerPrimerNombreApellido(string nombreCompleto)
        {
            string[] palabras = nombreCompleto.Split(' ');
            return new string[]
            {
        palabras.Length > 0 ? palabras[0] : string.Empty, 
        palabras.Length > 1 ? palabras[2]: string.Empty 
            };
        }

    }
}
