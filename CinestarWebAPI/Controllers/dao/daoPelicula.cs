using webCinestarMVC.Models;

namespace webCinestarMVC.Controllers.dao
{
    public class daoPelicula
    {
        bd.clsBD clsBD;
        public daoPelicula(IConfiguration config) {
            clsBD = new bd.clsBD(config, "cnCinestar");
        }

        internal List<Pelicula> getVerPeliculas(int id)
        {
            clsBD.Sentencia("sp_getPeliculas " + id);
            return new Pelicula().getList(clsBD.getRegistros());
        }

        internal Pelicula getVerPelicula(int idPelicula)
        {
            clsBD.Sentencia("sp_getPelicula " + idPelicula);
            var registros = clsBD.getRegistro();
            if (registros != null && registros.Length > 0)
                return new Pelicula(registros);
            return new Pelicula();
        }
    }
}
