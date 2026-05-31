namespace CompanySystem.DAL
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        /*------------------------------------------------------------------*/
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            
        }
        /*------------------------------------------------------------------*/
        //This method will make the changes permanent in the database
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------*/
    }
}
