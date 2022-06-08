using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IServices
{
    public interface ISubjectService
    {
        bool CreateSubject(Subject subject);
        bool DeleteSubject(int id);
        Subject GetSubject(int id);
        bool UpdateSubject(Subject subject);
    }
}
