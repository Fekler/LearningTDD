using LearningTDD.Domain.Interfaces;
using LearningTDD.Domain.Models;

namespace LearningTDD.InfraData.Repository
{
    public class StudentRepository(AppDbContext context) : BaseRepository<Student>(context), IStudentRepository
    {
    }
}
