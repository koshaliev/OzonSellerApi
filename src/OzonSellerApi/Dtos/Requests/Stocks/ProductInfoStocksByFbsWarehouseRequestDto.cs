using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonSellerApi.Dtos.Requests.Stocks;

// created: 29.01.2025
public class ProductInfoStocksByFbsWarehouseRequestDto
{
    /// <summary>
    /// SKU товара.
    /// </summary>
    public List<long> Sku { get; set; } = [];
}
