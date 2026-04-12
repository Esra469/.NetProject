namespace Core.Entities.Concrete
{
    //Nesneler tekil verileri s kullanılmaz.
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
