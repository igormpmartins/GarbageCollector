using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class Client
    {
        public int Id { get; set; }
        public string Nome { get; private set; }

        public Client(string nome)
        {
            Nome = nome;
        }

    }
}
