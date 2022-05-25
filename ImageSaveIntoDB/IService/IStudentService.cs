using ImageSaveIntoDB.Models;

namespace ImageSaveIntoDB.IService
{
    public interface IStudentService
    {
        Student Save(Student oStudent);

        Student GetSavedStudent();
    }
}
