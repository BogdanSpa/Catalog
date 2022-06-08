using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IServices
{
    public interface INoteService
    {
        bool CreateNote(Note nota);
        bool DeleteNote(int id);
        Note GetNote(int id);
        bool UpdateNote(Student student);
    }
}
