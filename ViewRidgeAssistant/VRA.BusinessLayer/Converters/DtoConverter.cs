using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.Dto;
using Vra.DataAccess.Entities;
using Vra.DataAccess;

namespace VRA.BusinessLayer.Converters
{
    public class DtoConverter
    {
        public static ArtistDto Convert(Artist artist)
        {
            if (artist == null)
                return null;
            ArtistDto artistDto = new ArtistDto();
            artistDto.Id = artist.ArtistId;
            artistDto.BirthYear = artist.BirthYear;
            artistDto.DeceaseYear = artist.DeceaseYear;
            artistDto.Name = artist.Name;
            artistDto.Nation = Convert(DaoFactory.GetNationDao().Get(artist.NationId));
            return artistDto;
        }

        public static Artist Convert(ArtistDto artistDto)
        {
            if (artistDto == null)
                return null;
            Artist artist = new Artist();
            artist.ArtistId = artistDto.Id;
            artist.BirthYear = artistDto.BirthYear;
            artist.DeceaseYear = artistDto.DeceaseYear;
            artist.Name = artistDto.Name;
            artist.NationId = artistDto.Nation.Id;
            return artist;
        }

        public static IList<ArtistDto> Convert(IList<Artist> artists)
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

        public static NationDto Convert(Nation nation)
        {
            if (nation == null)
                return null;
            NationDto nationDto = new NationDto();
            nationDto.Id = nation.Id;
            nationDto.Nationality = nation.Name;
            return nationDto;
        }

        public static Nation Convert(NationDto nationDto)
        {
            if (nationDto == null)
                return null;
            Nation nation = new Nation();
            nation.Id = nationDto.Id;
            nation.Name = nationDto.Nationality;
            return nation;
        }

        internal static IList<NationDto> Convert(IList<Nation> nationList)
        {
            var nations = new List<NationDto>();
            foreach (var nation in nationList)
            {
                nations.Add(Convert(nation));
            }
            return nations;
        }

        public static CustomerDto Convert(Customer customer)
        {
            if (customer == null)
                return null;
            CustomerDto customerDto = new CustomerDto();
            customerDto.Id = customer.CustomerId;
            customerDto.Name = customer.Name;
            customerDto.Email = customer.Email;
            customerDto.AreaCode = customer.AreaCode;
            customerDto.PhoneNumber = customer.PhoneNumber;
            customerDto.Street = customer.Street;
            customerDto.City = customer.City;
            customerDto.ZipPostalCode = customer.ZipPostalCode;
            customerDto.Country = customer.Country;
            customerDto.HouseNumber = customer.HouseNumber;
            customerDto.Region = customer.Region;
            return customerDto;
        }

        public static Customer Convert(CustomerDto customerDto)
        {
            if (customerDto == null)
                return null;
            Customer customer = new Customer();
            customer.CustomerId = customerDto.Id;
            customer.Name = customerDto.Name;
            customer.Email = customerDto.Email;
            customer.AreaCode = customerDto.AreaCode;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Street = customerDto.Street;
            customer.City = customerDto.City;
            customer.ZipPostalCode = customerDto.ZipPostalCode;
            customer.Country = customerDto.Country;
            customer.HouseNumber = customerDto.HouseNumber;
            customer.Region = customerDto.Region;
            return customer;
        }

        public static IList<CustomerDto> Convert(IList<Customer> customers)
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

        public static InterestsDto Convert(Interests interest)
        {
            if (interest == null) return null;

            InterestsDto Interest = new InterestsDto();

            Interest.Artist = Convert(DaoFactory.GetArtistDao().Get(interest.Artist));
            Interest.Customer = Convert(DaoFactory.GetCustomerDao().Get(interest.Customer));

            return Interest;

        }

        public static Interests Convert(InterestsDto interest)
        {
            if (interest == null) { return null; }

            Interests _interest = new Interests();
            _interest.Artist = interest.Artist.Id;
            _interest.Customer = interest.Customer.Id;

            return _interest;
        }

        public static IList<InterestsDto> Convert(IList<Interests> interest)
        {
            if (interest == null) return null;

            IList<InterestsDto> IntDto = new List<InterestsDto>();

            foreach (var interests in interest)
            {
                IntDto.Add(Convert(interests));
            }

            return IntDto;
        }

        public static WorkDto Convert(Work work)
        {
            if (work == null) { return null; }
            WorkDto workDto = new WorkDto();
            workDto.Id = work.Id;
            workDto.Title = work.Title;
            workDto.Artist = Convert(DaoFactory.GetArtistDao().Get(work.ArtistId));
            workDto.Copy = work.Copy;
            workDto.Description = work.Description;
            return workDto;
        }

        public static IList<WorkDto> Convert(IList<Work> works)
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
            Work work = new Work();
            work.Id = workDto.Id;
            work.Title = workDto.Title;
            work.ArtistId = workDto.Artist.Id;
            work.Copy = workDto.Copy;
            work.Description = workDto.Description;
            return work;
        }

        public static TransactionDto Convert(Transaction trans)
        {
            if (trans == null) return null;
            TransactionDto transDto = new TransactionDto();
            transDto.TransactionID = trans.TransID;
            transDto.Customer = Convert(DaoFactory.GetCustomerDao().Get(trans.CustomerID));
            transDto.Work = Convert(DaoFactory.GetWorkDao().Get(trans.WorkId));
            transDto.DateAcquired = trans.DateAcquired;
            transDto.AcquisitionPrice = trans.AcquisitionPrice;
            transDto.PurchaseDate = trans.PurchaseDate;
            transDto.SalesPrice = trans.SalesPrice;
            transDto.AskingPrice = trans.AskingPrice;
            return transDto;
        }

        public static Transaction Convert(TransactionDto transDto)
        {
            if (transDto == null) return null;
            Transaction trans = new Transaction();

            trans.TransID = transDto.TransactionID;
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

        public static IList<TransactionDto> Convert(IList<Transaction> transes)
        {
            if (transes == null) return null;

            IList<TransactionDto> transDtos = new List<TransactionDto>();
            foreach (var trans in transes)
            {
                transDtos.Add(Convert(trans));
            }
            return transDtos;
        }

        public static ReportItemDto Convert(Report report)
        {
            if (report == null) { return null; }

            ReportItemDto reportdto = new ReportItemDto();
            reportdto.date = report.date;
            reportdto.count = report.count;
            reportdto.price = report.price;

            return reportdto;
        }

        public static IList<ReportItemDto> Convert(IList<Report> reports)
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
