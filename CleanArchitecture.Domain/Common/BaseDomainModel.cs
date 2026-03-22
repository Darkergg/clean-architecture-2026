namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? LastModifieddDate { get; set; }

        public string? LastModifiedBy { get; set; } 
    }
}
