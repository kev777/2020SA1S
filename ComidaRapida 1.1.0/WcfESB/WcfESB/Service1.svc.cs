using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfESB
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public int Acceso(string usuario, string pass) //implementación de función de interface que indica el acceso de login por parte del cliente.
        {
            WcfCliente.Service1Client cliente = new WcfCliente.Service1Client(); //se manda a llamar al servicio del cliente.
            return cliente.login(usuario, pass); //se hace uso de uno de los métodos del servicio del cliente.
        }

        public string Asigna_Pedido_Repartidor(int monto, string producto)
        {
            WcfPedido.Service1Client pedido = new WcfPedido.Service1Client(); //se manda a llamar al servicio encargado de los pedidos.
            WcfRepartidor.Service1Client repar = new WcfRepartidor.Service1Client(); //se manda a llamar al servicio encargado de los repartidores.
            int respuesta = 0;
            string cod_repartidor = string.Empty;

            respuesta = pedido.insertar(monto, producto); // toma el valor de lo devuelto por parte del servicio de pedidos.
            if (respuesta == 1) //si el pedido fue insertado exitosamente, asigna el código de repartidor.
            {
                cod_repartidor = repar.asignar();
            }


            return cod_repartidor;
        }



        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
