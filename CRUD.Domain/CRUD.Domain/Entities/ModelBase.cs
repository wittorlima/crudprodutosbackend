namespace CRUD.Domain.Entities
{
    public class ModelBase
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as ModelBase;
            if (other == null)
                return false;
            return other.Id == this.Id;
        }
    }
}
