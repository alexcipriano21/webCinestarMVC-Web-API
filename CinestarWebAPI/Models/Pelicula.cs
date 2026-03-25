namespace webCinestarMVC.Models
{
    public class Pelicula
    {
        public int idPelicula { get; set; }
        public string Titulo { get; set; }
        public string FechaEstreno { get; set; }
        public string Director { get; set; }
        public string Generos { get; set; }
        public int idClasificacion { get; set; }
        public int idEstadoPelicula { get; set; }
        public bool Eliminado { get; set; }
        public string Duracion { get; set; }
        public string Link { get; set; }
        public string Reparto { get; set; }
        public string Sinopsis { get; set; }

        public bool Valido { get; set; }
        
        public Pelicula() {}

        public Pelicula(string[] aRegistro) 
        {
            setRegistro(aRegistro);
        }

        private void setRegistro(string[] aRegistro)
        {
            Valido = aRegistro !=null;
            if (!Valido) return;

            idPelicula = int.Parse(aRegistro[0]);
            Titulo = aRegistro[1];
            if (aRegistro.Length == 4)
            {
                Link = aRegistro[2];
                Sinopsis = aRegistro[3];
            }
            else
            {
                FechaEstreno = aRegistro[2];
                Director = aRegistro[3];
                Generos = aRegistro.Length > 11 ? aRegistro[11] : aRegistro[4];
                idClasificacion = int.Parse(aRegistro[5]);
                idEstadoPelicula = int.Parse(aRegistro[6]);
                Eliminado = false;
                Duracion = aRegistro[7];
                Link = aRegistro[8];
                Reparto = aRegistro[9];
                Sinopsis = aRegistro[10];
            }
        }
        
        internal List<Pelicula> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;

            List<Pelicula> lstlista = new List<Pelicula>();
            foreach (string[] aRegistro in mRegistros)
            {
                lstlista.Add(new Pelicula(aRegistro));
            }
            return lstlista;
        }
    }
}
