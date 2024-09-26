using System;

namespace SP4
{
    public class Nodo
    {
        public int Cuenta { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoMovimiento { get; set; }
        public float Importe { get; set; }
        public int CodigoSucursal { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo()
        {
            this.Cuenta = 0;
            this.Fecha = DateTime.Now.Date;
            this.TipoMovimiento = 0;
            this.Importe = 0;
            this.CodigoSucursal = 0;
            this.Siguiente = null;
        }
    }
}
