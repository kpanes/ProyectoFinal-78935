using System;
using System.ServiceModel;

namespace iproductos{
    [ServiceContract]
    public interface iProductos{
        [OperationContract]
        public List<string> historialProductos();
        [OperationContract]
        public string agregarProducto(string nombre,double precio);
        [OperationContract]
        public string solicitarProducto(int id);

    
    }
}