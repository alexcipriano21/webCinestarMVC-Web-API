namespace webCinestarMVC.Models
{
    public class Cine
    {
        public int idCine { get; set; }
        public string RazonSocial { get; set; }
        public int Salas { get; set; }
        public int idDistrito { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public bool Eliminado { get; set; }

        public bool Valido { get; set; }
        public string Detalle { get; set; }

        public Cine() { }

        public Cine(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }

        internal void setRegistro(string[] aRegistro)
        {
            Valido = aRegistro != null;
            if (!Valido) return;

            idCine = int.Parse(aRegistro[0]);
            RazonSocial = aRegistro[1];
            Salas = int.Parse(aRegistro[2]);
            idDistrito = int.Parse(aRegistro[3]);
            Direccion = aRegistro[4];
            Telefonos = aRegistro[5];
            Eliminado = false;
            Detalle = aRegistro.Length > 6 ? aRegistro[6] : "";
        }

        internal List<Cine> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;

            List<Cine> lstCines = new List<Cine>();
            foreach (string[] aRegistro in mRegistros)
                lstCines.Add(new Cine(aRegistro));
            return lstCines;
        }
    }
}
