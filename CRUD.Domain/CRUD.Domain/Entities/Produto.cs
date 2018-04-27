using CRUD.Domain.Constants;
using System;

namespace CRUD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCompra { get; set; }
        public byte[] Imagem { get; set; }
        public decimal Preco { get; set; }
        public Origem Origem { get; set; }
    }
}
