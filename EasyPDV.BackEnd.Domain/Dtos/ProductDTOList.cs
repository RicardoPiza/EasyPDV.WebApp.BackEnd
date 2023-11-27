using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class ProductDTOList
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string OwnerUserEmail { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string OrderByColumn { get; set; }
        public bool Desc { get; set; }
        public Termo Termo { get; set; }
    }
    public class Termo
    {
        public string DataField { get; set; }
        public string Value { get; set; }
        public string Operation { get; set; }
    }
}
