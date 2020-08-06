using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro.Execeptions {
    class DomainExceptions : ApplicationException{
        public DomainExceptions(string menssage) : base(menssage){

        }
    }
}
