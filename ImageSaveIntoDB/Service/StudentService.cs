using ImageSaveIntoDB.Context;
using ImageSaveIntoDB.IService;
using ImageSaveIntoDB.Models;
using System.Linq;

namespace ImageSaveIntoDB.Service
{
    public class StudentService : IStudentService
    {
        private readonly DatabaseContext _context;

        public StudentService(DatabaseContext context)
        {
            _context = context;
        }

        public Student GetSavedStudent()
        {
            return _context.Students.SingleOrDefault();
        }

        public Student Save(Student oStudent)
        {
            _context.Students.Add(oStudent);
            _context.SaveChanges();
            return oStudent;
        }
    }
}
