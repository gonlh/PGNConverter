using System;
using System.Collections.Generic;

namespace Modelo
{
    public enum Estado
    {
        JugadaBlancaSinCargar = 0,
        JugadaBlancaCargada = 1,
        JugadaNegraSinCargar = 2,
        JugadaNegraCargada = 3        
    }
    public class Jugada
    {
        private string _comentarioPosteriorBlanco;
        private string _jugadaBlanco;
        private string _comentarioPrevioBlanco;
        private int _numeroJugada;
        private string _comentarioPrevioNegro;
        private string _jugadaNegro;
        private string _comentarioPosteriorNegro;
        private List<Variante> _variantesBlanco;
        private List<Variante> _variantesNegro;
        private Estado _estado;

        public int NumeroJugada { get => _numeroJugada; set => _numeroJugada = value; }
        public string ComentarioPrevioBlanco { get => _comentarioPrevioBlanco; set => _comentarioPrevioBlanco = value; }
        public string JugadaBlanco { get => _jugadaBlanco; set => _jugadaBlanco = value; }
        public string ComentarioPosteriorBlanco { get => _comentarioPosteriorBlanco; set => _comentarioPosteriorBlanco = value; }
        public string ComentarioPrevioNegro { get => _comentarioPrevioNegro; set => _comentarioPrevioNegro = value; }
        public string JugadaNegro { get => _jugadaNegro; set => _jugadaNegro = value; }
        public string ComentarioPosteriorNegro { get => _comentarioPosteriorNegro; set => _comentarioPosteriorNegro = value; }
        public List<Variante> VariantesBlanco { get => _variantesBlanco; set => _variantesBlanco = value; }
        public List<Variante> VariantesNegro { get => _variantesNegro; set => _variantesNegro = value; }

        public Estado Estado { get => _estado; set => _estado = value; }

        public Jugada(int numeroJugada)
        {
            _numeroJugada = numeroJugada;
            _estado = Estado.JugadaBlancaSinCargar;
        }
    }
}
