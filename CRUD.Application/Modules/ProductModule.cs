using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Domain.Entities;
using CRUD.Domain.Exceptions;
using CRUD.Domain.Interfaces.Services;
using Nancy;
using Nancy.ModelBinding;
using System;

namespace CRUD.Application.Modules
{
    public class ProductModule : ModuleBase
    {
        public IProductService ProductService;

        public ProductModule(IProductService productService)
            : base("/products")
        {
            ProductService = productService;
        }

        protected override void RegisterRoutes()
        {
            Get["/"] =  Find;
            Get["/{id}"] = FindById;
            Post["/"] = Save;
        }

        private dynamic Find(dynamic parameters)
        {
            try
            {
                var resultResponse = ProductService.GetAll();

                return this.SerializeObject(resultResponse);
            }
            catch (Exception exception)
            {
                if (exception is InvalidParameterException)
                    return ExceptionResponse(exception, HttpStatusCode.BadRequest);
                return ExceptionResponse(exception, HttpStatusCode.InternalServerError);
            }
        }

        private dynamic FindById(dynamic parameters)
        {
            try
            {
                var id = (int)parameters.Id;
                var product = ProductService.GetById(id);
                var productDTO = Mapper.Map<ProductDTO>(product);

                return this.SerializeObjectWithoutTimeZone(productDTO);
            }
            catch (Exception exception)
            {
                if (exception is InvalidParameterException)
                    return ExceptionResponse(exception, HttpStatusCode.BadRequest);

                return ExceptionResponse(exception, HttpStatusCode.InternalServerError);
            }
        }

        private dynamic Save(dynamic parameters)
        {
            try
            {
                var ProductDTO = this.Bind<ProductDTO>();
                var product = Mapper.Map<Product>(ProductDTO);

                ProductService.SaveOrUpdate(product);

                return this.SerializeObject(ProductDTO);
            }
            catch (Exception exception)
            {
                if (exception is InvalidParameterException)
                    return ExceptionResponse(exception, HttpStatusCode.BadRequest);

                return ExceptionResponse(exception, HttpStatusCode.InternalServerError);
            }
        }
    }
}