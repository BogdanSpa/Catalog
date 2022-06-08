using Catalog.DTOModels;
using Catalog.Mapping;
using EFORM.Models;
using Repository.Features;
using Repository.Models;
using Repository.Services;

namespace ConsoleAppDBB // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _dbContext = new CatalogHomeworkContext();
            var _catalogService = new CatalogService(_dbContext);
            var _studentService = new StudentService(_dbContext);
            
            var _noteFeature = new NoteFeatures(_dbContext);
            var _studentFeature = new StudentFeatures(_dbContext);
            var _subjectFeature = new SubjectFeatures(_dbContext);
            var _catalogFeature = new CatalogFeatures(_dbContext);

            //1
            //Console.WriteLine("Studentii pt clasa XII: ");
            //var resp = _studentFeature.GetStudentsByClass("XII");
            //foreach(var student in resp)
            //{
            //    Console.WriteLine($"{student.Nume}    ");
            //}

            //2
            //CreateCatalogModel catalog = new CreateCatalogModel
            //{
            //    Clasa = "XII-C",
            //    Active = true,
            //};
            //AddCatalog(_catalogService, catalog);

            //3
            //var catalogFeature = new CatalogFeatures(_dbContext);

            //Console.WriteLine("Studentii pentru catalogul cu id 1: ");
            //var studentsForCatalog = catalogFeature.GetStudentsByCatalog(1);
            //foreach(var student in studentsForCatalog)
            //{
            //    Console.WriteLine($"{student.Id} -- {student.Nume} -- {student.Prenume}");
            //}

            //Console.WriteLine("Materiile pentru catalogul cu id 1: ");
            //var subjectsForCatalog = catalogFeature.GetSubjectsForCatalog(1);
            //foreach(var subject in subjectsForCatalog)
            //{
            //    Console.WriteLine($"{subject.Id} -- {subject.Nume} -- {subject.PredataInAn}");
            //}

            //Console.WriteLine("Notele pentru catalogul cu id 1: ");
            //var notesForCatalog = catalogFeature.GetNotesForCatalog(1);
            //foreach(var note in notesForCatalog)
            //{
            //    Console.WriteLine($"{note.NotaId} -- {note.Student} -- {note.Nota} -- {note.Materie}");
            //}

            //4
            //CreateStudentModel teo = new CreateStudentModel
            //{
            //    AnUniversitar = 3,
            //    Nume = "Manasoi",
            //    Prenume = "Teodor"
            //};
            //AddStudent(_studentService, teo);
            //CreateNoteModel notaTeo = new CreateNoteModel { StudentId = 1002}
            //noteTeo.Add(new Note { }
            //_noteFeature.AddNoteForStudentId(1002, 2, 2, 1);
            //_noteFeature.AddNoteForStudentId(1, 2, 2, 1);
            //CreateStudentWithNotesModel student = new CreateStudentWithNotesModel
            //{
            //    Nume = "Manasoi",
            //    Prenume = "Teodor",
            //    AnUniversitar = 3,
            //    Notes = new List<Note>()
            //};

            //5
            //AddSubjectToCatalog(_subjectFeature,2, 3);
            //7
            //var notesForSubjectForStudentId = _studentFeature.GetNotesForSubjectByStudent(2);

            //foreach(var subject in notesForSubjectForStudentId)
            //{
            //    Console.Write(subject.Subject);
            //    Console.WriteLine();

            //    foreach(var nota in subject.Notes)
            //    {
            //        Console.WriteLine(nota);
            //    }
            //}

            //8
            //var catalogsForSubjectId = _subjectFeature.GetAllCatalogsForSubjectId(1);

            //foreach(var catalog in catalogsForSubjectId)
            //{
            //    Console.WriteLine($"Id catalog: {catalog.Id} -- Clasa: {catalog.Clasa}");
            //}

            //9
            //var allStudentsWithNotesOnSubjectCatalog = _studentFeature.GetStudentsWithNotesOnSubjectCatalog(2, 1);

            //foreach(var student in allStudentsWithNotesOnSubjectCatalog)
            //{
            //    Console.WriteLine($"{student.Nume}");
            //}

            //10
            var averageForEachSubject = _catalogFeature.GetAverageForEachSubject(1);

            foreach (var student in averageForEachSubject)
            {
                Console.WriteLine($"{student.Student} --- {student.Subject} --- {student.Average}");
            }
        }

        //Ex 2
        static void AddCatalog(CatalogService _service, CreateCatalogModel catalog)
        {
            EFORM.Models.Catalog model = catalog.ToCatalogModel();
            _service.CreateCatalog(model);
        }

        static void AddStudent(StudentService _service, CreateStudentModel student)
        {
            Student model = student.ToStudentModel();
            _service.CreateStudent(model);
        }
        
        static void AddSubjectToCatalog(SubjectFeatures _feature, int subjectID, int catalogID)
        {
            _feature.AddSubjectToCatalog(subjectID, catalogID);
        }
    }
}