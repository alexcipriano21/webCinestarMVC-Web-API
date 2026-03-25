namespace webCinestarMVC.Models
{
    public class CinePelicula
    {
        public string Titulo { get; set; }
        public string Horario { get; set; }

        public CinePelicula() { }

        public CinePelicula(string Titulo, string Horario)
        {
            this.Titulo = Titulo;
            this.Horario = Horario;
        }

        internal dynamic getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;

            List<CinePelicula> lstLista = new List<CinePelicula>();
            foreach (string[] aRegistro in mRegistros)
                lstLista.Add(new CinePelicula(aRegistro[0], aRegistro[1]));
            return lstLista;
        }
    }
}
