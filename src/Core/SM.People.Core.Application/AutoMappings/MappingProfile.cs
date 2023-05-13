using AutoMapper;
using SM.MQ.Models.Supplier;
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
        }
    }
}
