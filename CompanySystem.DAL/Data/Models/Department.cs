namespace CompanySystem.DAL
{
    public class Department : IAuditableEntity
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }
        public required string Name { get; set; }
        /*------------------------------------------------------------------*/
        public virtual ICollection<Employee> Employees { get; set; }
        = new HashSet<Employee>();
        /*------------------------------------------------------------------*/
        // Audit Fields
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        /*------------------------------------------------------------------*/
    }
}

// CreatedAt
// UpdatedAt
// CreatedBy
// UpdatedBy
// LastAccessedAt
// LastPasswordChangeAt
// LastProfileUpdateAt