namespace EDA.Core.Domain;

public abstract class Entity 
{
   public Guid Id { get; set; }

   protected Entity() {
      if (string.IsNullOrEmpty(Id.ToString()))
      {
         Id = Guid.NewGuid();
      }
   }
}