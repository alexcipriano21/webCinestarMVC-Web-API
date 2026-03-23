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
        public int idEstado { get; set; }
        public string Duracion { get; set; }
        public string Link { get; set; }
        public string Reparto { get; set; }
        public string Sinopsis { get; set; }
        public string GenerosDetalle { get; set; }

        public Pelicula() { }

        public Pelicula(string[] aRegistro)
        {
            setResumen(aRegistro);
        }

        internal void setResumen(string[] aRegistro)
        {
            if (aRegistro == null) return;
            idPelicula = int.Parse(aRegistro[0]);
            Titulo = aRegistro[1];
            Link = aRegistro[2];
            Sinopsis = aRegistro[3];
        }
        internal void setDetalle(string[] aRegistro)
        {
            if (aRegistro == null) return;
            idPelicula = int.Parse(aRegistro[0]);
            Titulo = aRegistro[1];
            FechaEstreno = aRegistro[2];
            Director = aRegistro[3];
            Generos = aRegistro[4];
            idClasificacion = int.Parse(aRegistro[5]);
            idEstado = int.Parse(aRegistro[6]);
            Duracion = aRegistro[7];
            Link = aRegistro[8];
            Reparto = aRegistro[9];
            Sinopsis = aRegistro[10];
            GenerosDetalle = aRegistro.Length > 11 ? aRegistro[11] : "";
        }

        internal List<Pelicula> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;

            List<Pelicula> lstPeliculas = new List<Pelicula>();
            foreach (string[] aRegistro in mRegistros)
                lstPeliculas.Add(new Pelicula(aRegistro));
            return lstPeliculas;
        }
    }
}
