﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace myService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreService" in both code and config file together.
    [ServiceContract]
    public interface IStoreService
    {
        [OperationContract]
        bool LoginUser(string username, string password);

        [OperationContract]
        string InsertCustomer(string value);

        [OperationContract]
        List<ProductDTO> GetAllProducts();

        [OperationContract]
        Boolean BuyProduct(int aantal, string product, string username);

        [OperationContract]
        List<ProductDTO> GetMyInventory(string username);

        [OperationContract]
        double GetSaldo(string username);
    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "myService.ContractType".

    [DataContract]
    public class ProductDTO
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int Stock { get; set; }
    }

    [DataContract]
    public class CustomerDTO
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public double Saldo { get; set; }

    }

    [DataContract]
    public class OrderDTO
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int Aantal { get; set; }

        [DataMember]
        public int ProductId { get; set; }
    }

}

