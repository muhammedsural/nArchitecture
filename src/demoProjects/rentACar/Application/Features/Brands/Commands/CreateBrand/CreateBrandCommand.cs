using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        //Apiden gelen Brand ekleme isteğini IRequstHandler(Mediatr) vasıtasıyla ekliyor database. İhtiyacımız olan fieldları ihtiyaca göre burada tanımlamalıyız. Brandde sadece name lazım bize
        public string Name { get; set; }

        //Apiden gelen commandin kimin handle edeceğinin belirtir. Apide mediator üzerinden gönderilir ve burada uygulanır.
        //CreateBrandCommand => request ; CreatedBrandDto => response
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository; //Veritabanı işlemleri için yapılan injection
            private readonly IMapper _mapper; //Mapleme için automapper injection
            private readonly BrandBusinessRules _brandBusinessRules; //Ekleme işlemi ile ilgili iş kontrollerini enjekte edim kontrol ettikten sonra ekleme işlemi yapılmalı

            public CreateBrandCommandHandler(IBrandRepository brandRepository,IMapper mapper, BrandBusinessRules brandBussinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBussinessRules;
            }


            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);//Aynı isimde ürün olup olmadığını kontrol ediyorum

                Brand mappedBrand = _mapper.Map<Brand>(request);//Veritabanına nesne göndermemiz lazım gönderilen command ile entity eşler burada gelen commandi brande mapledik.
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);//Yukarıda maplediğim commendi veri tabanına gönderiyorum, nesneyi yakalıyorum
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);//Veritabanından yakaladığım nesneyi Son kullanıcıya göndermek istediğim kolonları DTO vasıtasıyla mapleyerek gönderiyorum. Gizlilik açısından önemli.Göndermek istemediğim kolonları göndermiyorum bu şekilde.

                return createdBrandDto;
            }
        }
    }
}
