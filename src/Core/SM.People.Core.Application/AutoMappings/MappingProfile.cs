using AutoMapper;
using SM.MQ.Models.Customer;
using SM.MQ.Models.Supplier;
using SM.People.Core.Application.Commands.Customer;
using SM.People.Core.Application.Commands.Supplier;
using SM.People.Core.Application.Models;
using SM.People.Core.Domain.Entities;
using SM.People.Core.Domain.ValueObjects;

namespace SM.People.Core.Application.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Add Supplier Command
            CreateMap<SupplierModel, AddSupplierCommand>().ReverseMap();
            CreateMap<AddSupplierCommand, Supplier>().ConstructUsing(b => new Supplier(
                    b.CorporateName,
                    b.FantasyName,
                    b.NRLE,
                    b.StateRegistration,
                    b.CellPhone,
                    new Email(b.EmailAddress),
                    new Address(b.PublicPlace,
                    b.District,
                    b.City,
                    b.ZipCode,
                    b.State)));

            CreateMap<Supplier, AddSupplierCommand>().ConstructUsing(b => new AddSupplierCommand(
                       b.Id,
                       b.CorporateName,
                       b.FantasyName,
                       b.NRLE,
                       b.StateRegistration,
                       b.CellPhone,
                       b.Email.EmailAddress,
                       b.Address.PublicPlace,
                       b.Address.District,
                       b.Address.City,
                       b.Address.ZipCode,
                       b.Address.State));

            //Update Supplier Command
            CreateMap<SupplierModel, UpdateSupplierCommand>().ReverseMap();
            CreateMap<UpdateSupplierCommand, Supplier>().ConstructUsing(b => new Supplier(
                    b.CorporateName,
                    b.FantasyName,
                    b.NRLE,
                    b.StateRegistration,
                    b.CellPhone,
                    new Email(b.EmailAddress),
                    new Address(b.PublicPlace,
                    b.District,
                    b.City,
                    b.ZipCode,
                    b.State)));

            CreateMap<Supplier, SupplierModel>().ConstructUsing(b => new SupplierModel(
                                  b.Id,
                                  b.CorporateName,
                                  b.FantasyName,
                                  b.NRLE,
                                  b.StateRegistration,
                                  b.CellPhone,
                                  b.Email.EmailAddress,
                                  b.Address.PublicPlace,
                                  b.Address.District,
                                  b.Address.City,
                                  b.Address.ZipCode,
                                  b.Address.State));


            CreateMap<SupplierModel, ResponseSupplierOut>().ReverseMap();


            //Add Customer Command
            CreateMap<CustomerModel, AddCustomerCommand>().ReverseMap();
            CreateMap<AddCustomerCommand, Customer>().ConstructUsing(b => new Customer(
                    b.FirstName,
                    b.LastName,
                    b.CellPhone,
                    b.Birthday,
                    new Email(b.EmailAddress),
                    new Address(b.PublicPlace,
                    b.District,
                    b.City,
                    b.ZipCode,
                    b.State)));

            CreateMap<Customer, AddCustomerCommand>().ConstructUsing(b => new AddCustomerCommand(
                       b.Id,
                       b.FirstName,
                       b.LastName,
                       b.CellPhone,
                       b.Birthday,
                       b.Email.EmailAddress,
                       b.Address.PublicPlace,
                       b.Address.District,
                       b.Address.City,
                       b.Address.ZipCode,
                       b.Address.State));

            //Update Customer Command
            CreateMap<CustomerModel, UpdateCustomerCommand>().ReverseMap();
            CreateMap<UpdateCustomerCommand, Customer>().ConstructUsing(b => new Customer(
                    b.FirstName,
                    b.LastName,
                    b.CellPhone,
                    b.Birthday,
                    new Email(b.EmailAddress),
                    new Address(b.PublicPlace,
                    b.District,
                    b.City,
                    b.ZipCode,
                    b.State)));

            CreateMap<Customer, CustomerModel>().ConstructUsing(b => new CustomerModel(
                       b.Id,
                       b.FirstName,
                       b.LastName,
                       b.CellPhone,
                       b.Birthday,
                       b.Email.EmailAddress,
                       b.Address.PublicPlace,
                       b.Address.District,
                       b.Address.City,
                       b.Address.ZipCode,
                       b.Address.State));


            CreateMap<CustomerModel, ResponseCustomerOut>().ReverseMap();
        }
    }
}
