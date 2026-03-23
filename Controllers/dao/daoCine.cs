namespace webCinestarMVC.Controllers.dao
{
    public class daoCine
    {
        bd.clsBD clsBD;

        public daoCine(IConfiguration config)
        {
            clsBD = new bd.clsBD("cnCinestar", config);
        }

        internal List<Models.Cine> getVerCines()
        {
            clsBD.Sentencia("sp_getCines");
            return new Models.Cine().getList(clsBD.getRegistro());
        }

        internal Models.Cine getCine(int idCine)
        {
            clsBD.Sentencia("sp_getCine " + idCine);
            Models.Cine cine = new Models.Cine();
            cine.setRegistro(clsBD.getRegistro()?[0]);
            return cine;
        }

        internal dynamic getCineTarifas(int idCine)
        {
            clsBD.Sentencia("sp_getCineTarifas " + idCine);
            return new Models.CineTarifa("", "").getList(clsBD.getRegistro());
        }

        internal dynamic getCinePeliculas(int idCine)
        {
            clsBD.Sentencia("sp_getCinePeliculas " + idCine);
            return new Models.CinePelicula("", "").getList(clsBD.getRegistro());
        }
    }
}
