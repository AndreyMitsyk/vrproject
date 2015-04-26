using System.Collections.Generic;
using VRA.Dto;
using Vra.DataAccess.Entities;
using Vra.DataAccess;

namespace VRA.BusinessLayer.Converters
{
    public static class DtoConverter
    {
        public static ArtistDto Convert(Artist artist)
        {
            if (artist == null)
                return null;
            ArtistDto artistDto = new ArtistDto
            {
                Id = artist.ArtistId,
                BirthYear = artist.BirthYear,
                DeceaseYear = artist.DeceaseYear,
                Name = artist.Name,
                Nation = Convert(DaoFactory.GetNationDao().Get(artist.NationId))
            };
            return artistDto;
        }

        public static Artist Convert(ArtistDto artistDto)
        {
            if (artistDto == null)
                return null;
            Artist artist = new Artist
            {
                ArtistId = artistDto.Id,
                BirthYear = artistDto.BirthYear,
                DeceaseYear = artistDto.DeceaseYear,
                Name = artistDto.Name,
                NationId = artistDto.Nation.Id
            };
            return artist;
        }

        public static IList<ArtistDto> Convert(IEnumerable<Artist> artists)
        {
            if (artists == null)
                return null;
            IList<ArtistDto> artistDtos = new List<ArtistDto>();
            foreach (var artist in artists)
            {
                artistDtos.Add(Convert(artist));
            }
            return artistDtos;
        }

        private static NationDto Convert(Nation nation)
        {
            if (nation == null)
                return null;
            NationDto nationDto = new NationDto {Id = nation.Id, Nationality = nation.Name};
            return nationDto;
        }

        public static Nation Convert(NationDto nationDto)
        {
            if (nationDto == null)
                return null;
            Nation nation = new Nation {Id = nationDto.Id, Name = nationDto.Nationality};
            return nation;
        }

        internal static IList<NationDto> Convert(IEnumerable<Nation> nationList)
        {
            var nations = new List<NationDto>();
            foreach (var nation in nationList)
            {
                nations.Add(Convert(nation));
            }
            return nations;
        }

        private static CustomerDto Convert(Customer customer)
        {
            if (customer == null)
                return null;
            CustomerDto customerDto = new CustomerDto
            {
                Id = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                AreaCode = customer.AreaCode,
                PhoneNumber = customer.PhoneNumber,
                Street = customer.Street,
                City = customer.City,
                ZipPostalCode = customer.ZipPostalCode,
                Country = customer.Country,
                HouseNumber = customer.HouseNumber,
                Region = customer.Region
            };
            return customerDto;
        }

        public static Customer Convert(CustomerDto customerDto)
        {
            if (customerDto == null)
                return null;
            Customer customer = new Customer
            {
                CustomerId = customerDto.Id,
                Name = customerDto.Name,
                Email = customerDto.Email,
                AreaCode = customerDto.AreaCode,
                PhoneNumber = customerDto.PhoneNumber,
                Street = customerDto.Street,
                City = customerDto.City,
                ZipPostalCode = customerDto.ZipPostalCode,
                Country = customerDto.Country,
                HouseNumber = customerDto.HouseNumber,
                Region = customerDto.Region
            };
            return customer;
        }

        public static IList<CustomerDto> Convert(IEnumerable<Customer> customers)
        {
            if (customers == null)
                return null;
            IList<CustomerDto> customerDtos = new List<CustomerDto>();

            foreach (var customer in customers)
            {
                customerDtos.Add(Convert(customer));
            }
            return customerDtos;
        }

        private static InterestsDto Convert(Interests interest)
        {
            if (interest == null) return null;

            InterestsDto Interest = new InterestsDto
            {
                Artist = Convert(DaoFactory.GetArtistDao().Get(interest.Artist)),
                Customer = Convert(DaoFactory.GetCustomerDao().Get(interest.Customer))
            };

            return Interest;

        }

        public static Interests Convert(InterestsDto interest)
        {
            if (interest == null) { return null; }

            Interests _interest = new Interests {Artist = interest.Artist.Id, Customer = interest.Customer.Id};

            return _interest;
        }

        public static IEnumerable<InterestsDto> Convert(IEnumerable<Interests> interest)
        {
            if (interest == null) return null;

            IList<InterestsDto> IntDto = new List<InterestsDto>();

            foreach (var interests in interest)
            {
                IntDto.Add(Convert(interests));
            }

            return IntDto;
        }

        private static WorkDto Convert(Work work)
        {
            if (work == null) { return null; }
            WorkDto workDto = new WorkDto
            {
                Id = work.Id,
                Title = work.Title,
                Artist = Convert(DaoFactory.GetArtistDao().Get(work.ArtistId)),
                Copy = work.Copy,
                Description = work.Description
            };
            return workDto;
        }

        public static IList<WorkDto> Convert(IEnumerable<Work> works)
        {
            if (works == null) return null;

            IList<WorkDto> workDtos = new List<WorkDto>();

            foreach (var work in works)
            {
                workDtos.Add(Convert(work));
            }

            return workDtos;
        }

        public static Work Convert(WorkDto workDto)
        {
            if (workDto == null)
                return null;
            Work work = new Work
            {
                Id = workDto.Id,
                Title = workDto.Title,
                ArtistId = workDto.Artist.Id,
                Copy = workDto.Copy,
                Description = workDto.Description
            };
            return work;
        }

        public static TransactionDto Convert(Transaction trans)
        {
            if (trans == null) return null;
            TransactionDto transDto = new TransactionDto
            {
                TransactionID = trans.TransID,
                Customer = Convert(DaoFactory.GetCustomerDao().Get(trans.CustomerID)),
                Work = Convert(DaoFactory.GetWorkDao().Get(trans.WorkId)),
                DateAcquired = trans.DateAcquired,
                AcquisitionPrice = trans.AcquisitionPrice,
                PurchaseDate = trans.PurchaseDate,
                SalesPrice = trans.SalesPrice,
                AskingPrice = trans.AskingPrice
            };
            return transDto;
        }

        public static Transaction Convert(TransactionDto transDto)
        {
            if (transDto == null) return null;
            Transaction trans = new Transaction {TransID = transDto.TransactionID};

            if (transDto.Customer != null)
            {
                trans.CustomerID = transDto.Customer.Id;
            }
            else
            {
                trans.CustomerID = null;
            }

            trans.WorkId = transDto.Work.Id;
            trans.DateAcquired = transDto.DateAcquired;
            trans.AcquisitionPrice = transDto.AcquisitionPrice;
            trans.PurchaseDate = transDto.PurchaseDate;
            trans.SalesPrice = transDto.SalesPrice;
            trans.AskingPrice = transDto.AskingPrice;

            return trans;
        }

        public static IList<TransactionDto> Convert(IEnumerable<Transaction> transes)
        {
            if (transes == null) return null;

            IList<TransactionDto> transDtos = new List<TransactionDto>();
            foreach (var trans in transes)
            {
                transDtos.Add(Convert(trans));
            }
            return transDtos;
        }

        private static ReportItemDto Convert(Report report)
        {
            if (report == null) { return null; }

            ReportItemDto reportdto = new ReportItemDto {date = report.date.ToString(), count = report.count, price = report.price};

            return reportdto;
        }

        public static IList<ReportItemDto> Convert(IEnumerable<Report> reports)
        {
            if (reports == null) { return null; }

            IList<ReportItemDto> ReportsDto = new List<ReportItemDto>();

            foreach (var r in reports)
            {
                ReportsDto.Add(Convert(r));
            }

            return ReportsDto;
        }
    }
}
