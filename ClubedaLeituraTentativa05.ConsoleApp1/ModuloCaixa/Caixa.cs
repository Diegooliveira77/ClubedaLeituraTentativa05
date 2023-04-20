using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeituraTentativa05.ConsoleApp1.ModuloCaixa
{ 
    public class Caixa 
{
    
    public int id; 
    public string cor;
    public string etiqueta;

    public Caixa(string c, string e)
    {
        cor = c;
        etiqueta = e;
    }
}
}
