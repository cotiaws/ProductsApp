using ProductsApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Interfaces.Messages
{
    public interface IEventProducer
    {
        void Publish(LogProdutos log);
    }
}
