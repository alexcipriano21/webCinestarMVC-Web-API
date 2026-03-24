using webCinestarMVC.Models;

namespace webCinestarMVC.Controllers.dao
{
    public class daoCine
    {
        bd.clsBD clsBD;
        public daoCine(IConfiguration config)
        {
            clsBD = new bd.clsBD(config, "cnCinestar");
        }

        internal List<Cine> getVerCines()
        {
            clsBD.Sentencia("sp_getCines");
            return new Cine().getList(clsBD.getRegistros());
        }

        internal Cine getCine(int idCine)
        {
            clsBD.Sentencia("sp_getCine " + idCine);
            Cine cine = new Cine();
            cine.setRegistro(clsBD.getRegistro());
            return cine;
        }

        internal dynamic getCineTarifas(int idCine)
        {
            clsBD.Sentencia("sp_getCineTarifas " + idCine);
            return new CineTarifa().getList(clsBD.getRegistros());
        }

        internal dynamic getCinePeliculas(int idCine)
        {
            clsBD.Sentencia("sp_getCinePeliculas " + idCine);
            return new CinePelicula().getList(clsBD.getRegistros());
        }
    }
}
