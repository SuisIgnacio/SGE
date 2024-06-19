using System.ComponentModel;

namespace SGE.Aplicacion;

public class ValidadorUsuario
{
    public bool ValidarContraseña(string password)
    {
        bool numero=false;
        bool mayus=false;
        foreach(char c in password)
        {
            if(Char.IsDigit(c)) numero=true;
            if(Char.IsUpper(c)) mayus=true;
        }
        return numero && mayus;
    }
}