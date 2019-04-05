using System.Collections.Generic;

namespace Modelo
{
    public class Variante
    {
        private int _numeroJugadaInicio;
        private bool _esVarianteNegra;
        private List<Jugada> _jugadas;

        public int NumeroJugadaInicio { get => _numeroJugadaInicio; set => _numeroJugadaInicio = value; }
        public bool EsVarianteNegra { get => _esVarianteNegra; set => _esVarianteNegra = value; }
        public List<Jugada> Jugadas { get => _jugadas; set => _jugadas = value; }

    public Variante(int numeroJugadaInicio)
    {
        _numeroJugadaInicio = numeroJugadaInicio;
    }


    }

}