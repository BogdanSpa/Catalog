using Catalog.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFORM.Models;
namespace Catalog.Mapping
{
    public static class ViewModelMapper
    {
        public static EFORM.Models.Catalog ToCatalogModel(this CreateCatalogModel catalog)
        {
            if(catalog == null)
            {
                return null;
            }
            else
            {
                return new EFORM.Models.Catalog
                {
                    Clasa = catalog.Clasa,
                    Active = catalog.Active,
                };
            }
        }

        public static Student ToStudentModel(this CreateStudentModel student)
        {
            if(student == null)
            {
                return null;
            }
            else
            {
                return new Student
                {
                    Nume = student.Nume,
                    AnUniversitar = student.AnUniversitar,
                    Prenume = student.Prenume,
                };
            }
        }

        public static Note ToNoteModel(this CreateNoteModel note)
        {
            if(note == null)
            {
                return null;
            }
            else
            {
                return new Note
                {
                    Nota = note.Nota,
                    
                    MaterieId = note.MaterieId,
                    
                    IssueDate = note.IssueDate,
                    
                    StudentId = note.StudentId,
                };
            }
        }
    }
}
