using Aplikasi_EX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOrderRepository
{
    Task<List<Order>> getSellerOrderAsync(int sellerid);
    Task<List<Order>> getBuyerOrderAsync(int buyerid);
}
