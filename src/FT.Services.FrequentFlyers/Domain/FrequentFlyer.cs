using FT.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FT.Services.FrequentFlyers.Enums.FrequentFlyerEnums;

namespace FT.Services.FrequentFlyers.Domain
{
    public class FrequentFlyer : BaseEntity
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();

        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Address { get; protected set; }
        public string Country { get; protected set; }
        public int MilesInAir { get; protected set; }
        public FrequentFlyerStatus Status { get; protected set; }
        public bool Completed => CompletedAt.HasValue;
        public DateTime? CompletedAt { get; protected set; }
        public IEnumerable<Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = new HashSet<Ticket>(value); }
        }

        protected FrequentFlyer(Guid id) : base(id)
        {
        }

        public FrequentFlyer(Guid id, string email) : base(id)
        {
            Id = id;
            Email = email;
            CreatedDate = DateTime.UtcNow;
        }

        public void Complete(string firstName, string lastName, string address, string country)
        {
            SetFullName(firstName, lastName);
            SetAddress(address);
            SetCountry(country);
            Status = FrequentFlyerStatus.NotFF;
            MilesInAir = 0;
            Tickets = new HashSet<Ticket>();
        }

        public void SetFullName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                throw new FTException("Fullname cannot be empty.");
            }

            FirstName = firstName;
            LastName = lastName;
            SetUpdatedDate();
        }

        public void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new FTException("Address cannot be empty.");
            }

            Address = address;
            SetUpdatedDate();
        }

        public void SetCountry(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                throw new FTException("Country cannot be empty.");
            }

            Country = country;
            SetUpdatedDate();
        }
    }
}
