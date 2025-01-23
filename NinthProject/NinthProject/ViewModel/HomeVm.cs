using Project.DAL.Entities;

namespace NinthProject.ViewModel
{
    public class HomeVm
    {
        public ICollection<Treatment> treatment { get; set; }
        public ICollection<Doctor> doctor { get; set; }
    }
}
