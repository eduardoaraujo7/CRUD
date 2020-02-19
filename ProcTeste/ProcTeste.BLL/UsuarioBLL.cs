using ProcTeste.DAL;
using ProcTeste.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcTeste.BLL
{
    public class UsuarioBLL
    {
        private ProcTesteRepository procTesteRepository;
        public bool InserirUsuario(Usuario usuario)
        {
            procTesteRepository = new ProcTesteRepository();

            if(usuario != null)
            {
                procTesteRepository.InserirUsuario(usuario);
                return true;
            }
            return false;
        }
    }
}
