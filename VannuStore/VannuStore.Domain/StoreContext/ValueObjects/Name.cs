using FluentValidator;
using FluentValidator.Validation;

namespace VannuStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Nome deve conter ao menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "FirstName", "Nome deve conter no máximo 30 caracters")
                .HasMinLen(LastName, 3, "LastName", "Sobrenome deve conter ao menos 3 caracteres")
                .HasMaxLen(LastName, 50, "LastName", "Sobrenome deve conter no máximo 50 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
