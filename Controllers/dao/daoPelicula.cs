namespace webCinestarMVC.Controllers.dao
{
    public class daoPelicula
    {
        bd.clsBD clsBD;

        public daoPelicula(IConfiguration config)
        {
            clsBD = new bd.clsBD("cnCinestar", config);
        }

        internal List<Models.Pelicula> getPeliculas(int idEstado)
        {
            clsBD.Sentencia("sp_getPeliculas " + idEstado);
            return new Models.Pelicula().getList(clsBD.getRegistro());
        }

        internal Models.Pelicula getPelicula(int idPelicula)
        {
            clsBD.Sentencia("sp_getPelicula " + idPelicula);
            var registros = clsBD.getRegistro();
            Models.Pelicula pelicula = new Models.Pelicula();
            if (registros != null && registros.Length > 0)
                pelicula.setDetalle(registros[0]);
            return pelicula;
        }
    }
}
